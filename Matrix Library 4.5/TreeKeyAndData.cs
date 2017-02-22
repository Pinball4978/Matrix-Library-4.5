using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix_Library_4_5
{
    public class TreeKey : IComparable
    {
        public int CompareTo(TreeKey key)
        {
            return 0;
        }

        public int CompareTo(object key)
        {
            TreeKey otherKey = key as TreeKey;
            return this.CompareTo(otherKey);
        }

        public override string ToString()
        {
            return "";
        }
    }

    public class TreeData : IComparable
    {
        public int CompareTo(TreeData data)
        {
            return 0;
        }

        public int CompareTo(object data)
        {
            TreeData otherData = data as TreeData;
            return this.CompareTo(otherData);
        }
    }
}
