using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LaunchMateTray
{
    public enum menuItemType { Application = 0, Group = 1 };
    public struct MenuItemInfo
    {
        public string id;
        public menuItemType itemType;
        public string itemName;
        public string itemPath;
        public uint order;
    };


    /*************************************
     * 
     * MenuListItem
     * 
     * ***********************************/
    class MenuListItem
    {
        protected MenuItemInfo info = new MenuItemInfo();
        protected List<MenuListItem>? children;
        protected MenuListItem? parent;

        public MenuListItem() {
            this.Init();
        }
        public MenuListItem(MenuItemInfo itemInfo)
        {
            this.info = itemInfo;
            this.Init();
        }

        public MenuListItem(JsonAppItem appItem)
        {
            this.Init();

            this.info.itemName = appItem.Name != null ? appItem.Name : "";

            switch (appItem.Type)
            {
                case "Group":
                    this.info.itemType = menuItemType.Group;
                    if (appItem.Children != null)
                    {
                        foreach (var child in appItem.Children)
                        {
                            this.AddChild(new MenuListItem(child));
                        }
                        
                    }
                    break;

                case "Application":
                    this.info.itemType=menuItemType.Application;
                    this.info.itemPath = appItem.Path != null ? appItem.Path : "";
                    break;
            }
        }

        private void Init()
        {
            this.parent = null;
            this.children = new List<MenuListItem>();
            this.GenerateId();
        }

        public void GenerateId()
        {
            this.info.id = Guid.NewGuid().ToString();
        }

        public string Id
        {
            get
            {
                return info.id;
            }
            set
            {
                info.id = value;
            }
        }

        public menuItemType Type
        {
            get
            {
                return info.itemType;
            }
            set
            {
                info.itemType = value;
            }
        }

        public string Name
        {
            get
            {
                return info.itemName;
            }
            set
            {
                info.itemName = value;
            }
        }

        public string Path
        {
            get
            {
                return info.itemPath;
            }
            set
            {
                info.itemPath = value;
            }
        }

        public void AddChild(MenuListItem child)
        {
            if (this.children != null) { this.children.Add(child); }
            child.SetParent(this);
        }

        public void SetParent(MenuListItem parent)
        {
            this.parent = parent;
        }

        public List<MenuListItem>? GetChildren()
        {
            return this.children;
        }

        public JsonAppItem Convert2JsonAppItem()
        {
            var ret = new JsonAppItem();
            switch (this.info.itemType)
            {
                case menuItemType.Application:
                    ret.Type = "Application";
                    ret.Name = this.info.itemName;
                    ret.Path = this.info.itemPath;
                    break;

                case menuItemType.Group:
                    ret.Type = "Group";
                    ret.Name = this.info.itemName;
                    if (this.children != null)
                    {
                        ret.Children = new List<JsonAppItem>();
                        foreach (MenuListItem child in this.children)
                        {
                            ret.Children.Add(child.Convert2JsonAppItem());
                        }
                    }
                    break;
            }
            return ret;
        }

        public void Copy(MenuListItem item)
        {

        }
    }

    /*************************************
     * 
     * MenuSortedDictionary
     * 
     * ***********************************/
    class MenuSortedDictionary : SortedDictionary<String, MenuListItem>
    {
    }

    /*************************************
     * 
     * MenuList
     * 
     * ***********************************/
    class MenuList
    {
        protected MenuListItem rootItem = new MenuListItem();
        protected MenuSortedDictionary itemMap = new MenuSortedDictionary();

        public MenuListItem Root { get; }

        public void AddChildItem(MenuItemInfo itemInfo, string parentId)
        {
            MenuListItem parent = this.rootItem;

            if (parentId.Length > 0 && itemMap.ContainsKey(parentId))
            {
                parent = itemMap[parentId];                
            }

            parent.AddChild(new MenuListItem(itemInfo));
        }

        public List<MenuListItem>? GetRootChildren()
        {
            return this.rootItem.GetChildren();
        }

        public void BuildDictionaryItem(MenuListItem item)
        {
            itemMap[item.Id] = item;
            var children = item.GetChildren();
            if (children != null)
            {
                foreach (var child in children)
                {
                    this.BuildDictionaryItem(child);
                }
            }
        }

        public void BuildDictionary()
        {
            List<MenuListItem>? rootChildren = this.rootItem.GetChildren();
            if (rootChildren != null)
            {
                foreach (MenuListItem item in rootChildren)
                {
                    this.BuildDictionaryItem(item);
                }
            }
        }

        public void UpdateSettings()
        {
            var settings = new LaunchMateTraySettings();
            settings.ReadSettings();
            List<MenuListItem>? rootChildren = this.rootItem.GetChildren();
            if (rootChildren != null)
            {
                var apps = new List<JsonAppItem>();
                foreach (MenuListItem item in rootChildren)
                {
                    apps.Add(item.Convert2JsonAppItem());
                }

                settings.Settings.Apps = apps;
                settings.WriteSettings();
            }
        }

        public void ImportSettings(List<JsonAppItem>? apps)
        {
            if (apps != null)
            {
                foreach (JsonAppItem item in apps)
                {
                    this.rootItem.AddChild(new MenuListItem(item));
                }
                this.BuildDictionary();
            }
        }

        public MenuListItem? FindMenuItem(String Id)
        {
            if (this.itemMap.ContainsKey(Id))
            {
                return this.itemMap[Id];
            }

            return null;
        }

        public void CopyMenuList(MenuList menuList)
        {
            this.rootItem = new MenuListItem();
            this.rootItem.Copy(menuList.Root);
        }
    }
}
