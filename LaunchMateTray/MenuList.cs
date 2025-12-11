using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Policy;
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
        public string itemArgs;
        public string itemIconPath;
        public uint order;
    };


    /*************************************
     * 
     * MenuListItem
     * 
     * ***********************************/
    public class MenuListItem : ICloneable, IEquatable<MenuListItem>, IComparable<MenuListItem>
    {
        protected MenuItemInfo info = new MenuItemInfo();
        protected List<MenuListItem>? children;
        protected MenuListItem? parent;

        public MenuListItem()
        {
            Init();
        }
        public MenuListItem(MenuItemInfo itemInfo)
        {
            info = itemInfo;
            Init();
        }

        public MenuListItem(JsonAppItem appItem)
        {
            Init();

            info.itemName = appItem.Name ?? "";
            info.itemIconPath = appItem.IconPath ?? "";

            switch (appItem.Type)
            {
                case "Group":
                    info.itemType = menuItemType.Group;
                    if (appItem.Children != null)
                    {
                        foreach (var child in appItem.Children)
                        {
                            AddChild(new MenuListItem(child));
                        }

                    }
                    break;

                case "Application":
                    info.itemType = menuItemType.Application;
                    info.itemPath = appItem.Path ?? "";
                    info.itemArgs = appItem.Arguments ?? "";
                    break;
            }
        }

        private void Init()
        {
            parent = null;
            children = new List<MenuListItem>();
            GenerateId();
        }

        public Object Clone()
        {
            MenuListItem ret = new MenuListItem(info);
            if (children != null)
            {
                foreach (var child in children)
                {
                    ret.AddChild((MenuListItem)child.Clone());
                }
            }
            return ret;
        }

        public void GenerateId()
        {
            info.id = Guid.NewGuid().ToString();
            switch (info.itemType)
            {
                case menuItemType.Group:
                    info.id = "g" + info.id;
                    break;
                case menuItemType.Application:
                    info.id = "a" + info.id;
                    break;
            }
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

        public string Arguments
        {
            get
            {
                return info.itemArgs;
            }
            set
            {
                info.itemArgs = value;
            }
        }

        public string IconPath
        {
            get
            {
                return info.itemIconPath;
            }
            set
            {
                info.itemIconPath = value;
            }
        }

        private Icon? ConvertImage2Icon(string path)
        {
            Icon? ret = null;
            Bitmap bitmap = new Bitmap(path);
            Bitmap resizedBitmap = new Bitmap(bitmap, new Size(16, 16));
            IntPtr hIcon = resizedBitmap.GetHicon();
            ret = Icon.FromHandle(hIcon);
            return ret;
        }

        public Icon? GetIcon()
        {
            Icon? ret = null;
            string exePath = info.itemPath;

            if (info.itemIconPath != null && info.itemIconPath.Length > 0 && File.Exists(info.itemIconPath))
            {
                if (System.IO.Path.GetExtension(info.itemIconPath).ToLower() == ".ico")
                {
                    ret = new Icon(info.itemIconPath);
                }
                else if (System.IO.Path.GetExtension(info.itemIconPath).ToLower() == ".png")
                {
                    ret = ConvertImage2Icon(info.itemIconPath);
                }
                else
                {
                    exePath = info.itemIconPath;
                }
            }

            if (ret == null) 
            {
                if (exePath != null && exePath.Length > 0)
                {
                    ret = Icon.ExtractAssociatedIcon(exePath);
                }
                else if (info.itemType == menuItemType.Group)
                {
                    ret = SystemIcons.GetStockIcon(StockIconId.Folder, 16);
                }
            }

            return ret;
        }

        public void AddChild(MenuListItem child)
        {
            if (children != null) { children.Add(child); }
            child.SetParent(this);
        }

        public void InsertChild(MenuListItem child, MenuListItem sibling)
        {
            if (children != null)
            {
                int index = children.IndexOf(sibling);
                children.Insert(index, child);
            }
        }

        public void RemoveChild(MenuListItem child)
        {
            children?.Remove(child);
        }

        public void SetParent(MenuListItem iparent)
        {
            parent = iparent;
        }

        public MenuListItem? GetParent()
        {
            return parent;
        }

        public List<MenuListItem>? GetChildren()
        {
            return children;
        }

        public JsonAppItem Convert2JsonAppItem()
        {
            var ret = new JsonAppItem();
            switch (info.itemType)
            {
                case menuItemType.Application:
                    ret.Type = "Application";
                    ret.Name = info.itemName;
                    ret.Path = info.itemPath;
                    ret.Arguments = info.itemArgs;
                    ret.IconPath = info.itemIconPath;
                    break;

                case menuItemType.Group:
                    ret.Type = "Group";
                    ret.Name = info.itemName;
                    ret.IconPath = info.itemIconPath;
                    if (children != null)
                    {
                        ret.Children = new List<JsonAppItem>();
                        foreach (MenuListItem child in children)
                        {
                            ret.Children.Add(child.Convert2JsonAppItem());
                        }
                    }
                    break;
            }
            return ret;
        }

        public void Sort()
        {
            if (children != null)
            {
                children.Sort();
                foreach (MenuListItem child in children)
                {
                    child.Sort();
                }
            }
        }

        public bool Equals(MenuListItem? other)
        {
            bool ret = false;

            if (other != null)
            {
                ret = Name == other.Name && Path == other.Path && Arguments == other.Arguments;
            }

            return ret;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as MenuListItem);
        }

        public int CompareTo(MenuListItem? item)
        {
            int ret = item != null ? Name.CompareTo(item.Name) : 1;

            return ret;
        }

        public override int GetHashCode()
        {
            return info.GetHashCode();
        }
    }

    /*************************************
     * 
     * MenuSortedDictionary
     * 
     * ***********************************/
    public class MenuSortedDictionary : SortedDictionary<String, MenuListItem>
    {
    }

    /*************************************
     * 
     * MenuList
     * 
     * ***********************************/
    public class MenuList: ICloneable
    {
        protected MenuListItem rootItem;
        protected MenuSortedDictionary itemMap;

        public MenuList()
        {
            rootItem = new MenuListItem();
            itemMap = new MenuSortedDictionary();
        }

        public MenuListItem Root { get { return rootItem; } }

        public void AddChildItem(MenuItemInfo itemInfo, string parentId)
        {
            MenuListItem parent = rootItem;

            if (parentId.Length > 0 && itemMap.ContainsKey(parentId))
            {
                parent = itemMap[parentId];                
            }

            parent.AddChild(new MenuListItem(itemInfo));
        }

        public List<MenuListItem>? GetRootChildren()
        {
            return rootItem.GetChildren();
        }

        public void BuildDictionaryItem(MenuListItem item)
        {
            itemMap[item.Id] = item;
            var children = item.GetChildren();
            if (children != null)
            {
                foreach (var child in children)
                {
                    BuildDictionaryItem(child);
                }
            }
        }

        public void BuildDictionary()
        {
            List<MenuListItem>? rootChildren = rootItem.GetChildren();
            if (rootChildren != null)
            {
                foreach (MenuListItem item in rootChildren)
                {
                    BuildDictionaryItem(item);
                }
            }
        }

        public void UpdateSettings(bool write=true)
        {
            var settings = new LaunchMateTraySettings();
            settings.ReadSettings();
            List<MenuListItem>? rootChildren = rootItem.GetChildren();
            if (rootChildren != null)
            {
                var apps = new List<JsonAppItem>();
                foreach (MenuListItem item in rootChildren)
                {
                    apps.Add(item.Convert2JsonAppItem());
                }

                settings.Settings.Apps = apps;
                if (write)
                {
                    settings.WriteSettings();
                }
            }
        }

        public void ImportSettings(List<JsonAppItem>? apps)
        {
            if (apps != null)
            {
                foreach (JsonAppItem item in apps)
                {
                    rootItem.AddChild(new MenuListItem(item));
                }
                BuildDictionary();
            }
        }

        public MenuListItem? FindMenuItem(String Id)
        {
            if (itemMap.ContainsKey(Id))
            {
                return itemMap[Id];
            }

            return null;
        }

        public Object Clone()
        {
            var ret = new MenuList();
            var children = GetRootChildren();
            if (children != null)
            {
                foreach (var child in children)
                {
                    ret.Root.AddChild((MenuListItem)child.Clone());
                }

            }

            ret.BuildDictionary();

            return ret;
        }

        public void Sort()
        {
            rootItem.Sort();
        }
    }
}
