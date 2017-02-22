using Matrix_Library_4_5;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix_Library_4_5
{
    public class AVLTree
    {
        private class AVLNode
        {
            int m_nodeHeight;
            TreeKey m_key;
            TreeData m_data;

            public TreeKey getKey()
            {
                return m_key;
            }

            public int getHeight()
            {
                return m_nodeHeight;
            }

            public void setHeight(int h)
            {
                m_nodeHeight = h;
            }

            public void setData(TreeData i)
            {
                m_data = i;
            }

            public int CompareTo(AVLNode otherNode)
            {
                return this.m_key.CompareTo(otherNode.m_key);
            }

            public AVLNode(TreeKey key, TreeData data)
            {
                m_key = key;
                m_data = data;
                m_nodeHeight = 1;
            }

            public AVLNode(TreeKey key)
            {
                m_key = key;
                m_nodeHeight = 1;
            }

            public TreeData getData()
            {
                return m_data;
            }
        }

        AVLNode m_node;
        AVLTree m_parent;
        AVLTree m_leftChild;
        AVLTree m_rightChild;

        public AVLTree(TreeKey key, TreeData data)
        {
            m_node = new AVLNode(key, data);
        }

        public AVLTree(TreeKey key)
        {
            m_node = new AVLNode(key);
        }

        private bool isInternal()
        {
            return (m_leftChild != null || m_rightChild != null);
        }

        private bool isExternal()
        {
            return (m_leftChild == null && m_rightChild == null);
        }

        private bool isRoot()
        {
            return (m_parent == null);
        }

        public AVLTree findRoot()
        {
            AVLTree ret = this;
            while (!ret.isRoot())
            {
                ret = ret.m_parent;
            }
            return ret;
        }

        private int getHeight()
        {
            return m_node.getHeight();
        }

        private void setHeight()
        {
            int leftHeight = 0;
            if (m_leftChild != null)
                leftHeight = m_leftChild.getHeight();
            int rightHeight = 0;
            if (m_rightChild != null)
                rightHeight = m_rightChild.getHeight();
            int maxHeight = Math.Max(leftHeight, rightHeight);
            m_node.setHeight(maxHeight + 1);
        }

        private bool isBalanced()
        {
            if (m_leftChild != null && m_rightChild != null)
            {
                int heightDifference = Math.Abs(m_leftChild.getHeight() - m_rightChild.getHeight());
                return (heightDifference <= 1);
            }
            else if (m_leftChild != null)
            {
                int heightDifference = m_leftChild.getHeight();
                return (heightDifference <= 1);
            }
            else if (m_rightChild != null)
            {
                int heightDifference = m_rightChild.getHeight();
                return (heightDifference <= 1);
            }
            else
            {
                return true;
            }
        }

        private void setLeftChild(AVLTree child)
        {
            m_leftChild = child;
        }

        private void setRightChild(AVLTree child)
        {
            m_rightChild = child;
        }

        private void setParent(AVLTree parent)
        {
            m_parent = parent;
        }

        private void addLeftChild(AVLTree left)
        {
            this.setLeftChild(left);
            if (left != null)
                left.setParent(this);
        }

        private void addRightChild(AVLTree right)
        {
            this.setRightChild(right);
            if (right != null)
                right.setParent(this);
        }

        private bool isALeftChild()
        {
            if (isRoot())
            {
                return false;
            }
            else
            {
                AVLTree parent = this.m_parent;
                return (parent.m_leftChild.Equals(this));
            }
        }

        private bool isARightChild()
        {
            if (isRoot())
            {
                return false;
            }
            else
            {
                AVLTree parent = this.m_parent;
                return (parent.m_rightChild.Equals(this));
            }
        }

        public int CompareTo(AVLTree otherTree)
        {
            return this.m_node.getKey().CompareTo(otherTree.m_node.getKey());
        }

        private AVLTree find(TreeKey key)
        {
            int comparison = this.m_node.getKey().CompareTo(key);
            if (comparison == 0)
            {
                return this;
            }
            else if (comparison > 0)
            {
                if (m_leftChild == null)
                    return null;
                else
                    return m_leftChild.find(key);
            }
            else if (comparison < 0)
            {
                if (m_rightChild == null)
                    return null;
                else
                    return m_rightChild.find(key);
            }
            return null;
        }

        private void Remove(TreeKey key)
        {
            AVLTree nodeToRemove = find(key);
            if (nodeToRemove != null)
            {
                AVLTree parent = nodeToRemove.m_parent;
                if (nodeToRemove.m_leftChild == null && nodeToRemove.m_rightChild == null)
                {
                    if (nodeToRemove.isALeftChild())
                        parent.m_leftChild = null;
                    else if (nodeToRemove.isARightChild())
                        parent.m_rightChild = null;
                    nodeToRemove.m_parent = null;
                    parent.setHeight();
                }
                else if (nodeToRemove.m_leftChild != null && nodeToRemove.m_rightChild == null)
                {
                    AVLTree leftKid = nodeToRemove.m_leftChild;
                    parent.m_leftChild = leftKid;
                    leftKid.m_parent = parent;
                    nodeToRemove.m_parent = null;
                    nodeToRemove.m_leftChild = null;
                    parent.setHeight();
                }
                else if (nodeToRemove.m_leftChild == null && nodeToRemove.m_rightChild != null)
                {
                    AVLTree rightKid = nodeToRemove.m_rightChild;
                    parent.m_rightChild = rightKid;
                    rightKid.m_parent = parent;
                    nodeToRemove.m_parent = null;
                    nodeToRemove.m_rightChild = null;
                    parent.setHeight();
                }
                else
                {
                    AVLTree replacementNode = nodeToRemove.m_rightChild;
                    while (replacementNode.m_leftChild != null)
                    {
                        replacementNode = replacementNode.m_leftChild;
                    }
                    AVLTree replacementNodeParent = replacementNode.m_parent;
                    if (replacementNode.m_rightChild == null)
                    {
                        replacementNode.m_parent.m_leftChild = null;
                        replacementNode.m_leftChild = nodeToRemove.m_leftChild;
                        replacementNode.m_rightChild = nodeToRemove.m_rightChild;
                        replacementNode.m_parent = nodeToRemove.m_parent;
                        nodeToRemove.m_parent = null;
                        nodeToRemove.m_leftChild = null;
                        nodeToRemove.m_rightChild = null;
                    }
                    else
                    {
                        replacementNode.m_rightChild.m_parent = replacementNode.m_parent;
                        replacementNode.m_parent.m_leftChild = replacementNode.m_rightChild;
                        replacementNode.m_leftChild = nodeToRemove.m_leftChild;
                        replacementNode.m_rightChild = nodeToRemove.m_rightChild;
                        replacementNode.m_parent = nodeToRemove.m_parent;
                        nodeToRemove.m_parent = null;
                        nodeToRemove.m_leftChild = null;
                        nodeToRemove.m_rightChild = null;
                    }
                    replacementNodeParent.setHeight();
                    while (replacementNodeParent.m_parent != null)
                    {
                        replacementNodeParent = replacementNodeParent.m_parent;
                        replacementNodeParent.setHeight();
                    }
                }
            }
        }

        private void rebalance()
        {
            AVLTree heightSetter = this;
            AVLTree root = this;
            while (!root.isRoot())
                root = root.m_parent;
            //using (TextWriter output = new StreamWriter("treeLogPreBalance.txt"))
            //{
            //    output.Write(root.print());
            //}
            while (!heightSetter.isRoot())
            {
                heightSetter = heightSetter.m_parent;
                heightSetter.setHeight();
                if (!heightSetter.isBalanced())
                {
                    AVLTree x = heightSetter.getTallGrandChild();
                    x.restructure();
                    while (!root.isRoot())
                        root = root.m_parent;
                    //using (TextWriter output = new StreamWriter("treeLogPostBalance.txt"))
                    //{
                    //    output.Write(root.print());
                    //}
                }
            }
            
        }

        private void restructure()
        {
            AVLTree x = this;
            AVLTree y = this.m_parent;
            AVLTree z = y.m_parent;
            AVLTree a, b, c;
            if (x.CompareTo(y) < 0 && x.CompareTo(z) < 0)
            {
                a = x;
                if (y.CompareTo(z) < 0)
                {
                    b = y;
                    c = z;
                }
                else
                {
                    b = z;
                    c = y;
                }
            }
            else if (y.CompareTo(x) < 0 && y.CompareTo(z) < 0)
            {
                a = y;
                if (x.CompareTo(z) < 0)
                {
                    b = x;
                    c = z;
                }
                else
                {
                    b = z;
                    c = x;
                }
            }
            else
            {
                a = z;
                if (x.CompareTo(y) < 0)
                {
                    b = x;
                    c = y;
                }
                else
                {
                    b = y;
                    c = x;
                }
            }
            AVLTree t0 = a.m_leftChild;
            AVLTree t3 = c.m_rightChild;
            AVLTree t1, t2;
            if (b.Equals(x))
            {
                t1 = b.m_leftChild;
                t2 = b.m_rightChild;
            }
            else if (a.Equals(z))
            {
                t1 = b.m_leftChild;
                t2 = c.m_leftChild;
            }
            else
            {
                t1 = a.m_rightChild;
                t2 = b.m_rightChild;
            }
            if (!z.isRoot() && z.isALeftChild())
            {
                z.m_parent.addLeftChild(b);
            }
            else if (!z.isRoot())
            {
                z.m_parent.addRightChild(b);
            }
            else if (z.isRoot())
            {
                b.m_parent = null;
            }
            b.addLeftChild(a);
            b.addRightChild(c);
            a.addLeftChild(t0);
            a.addRightChild(t1);
            c.addLeftChild(t2);
            c.addRightChild(t3);
            a.setHeight();
            c.setHeight();
            b.setHeight();
        }

        private AVLTree getTallGrandChild()
        {
            AVLTree tallGrandChild = null;
            if (this.m_leftChild != null && this.m_rightChild != null)
            {
                if (this.m_leftChild.getHeight() > this.m_rightChild.getHeight())
                    tallGrandChild = this.m_leftChild;
                else
                    tallGrandChild = this.m_rightChild;
            }
            else if (this.m_leftChild != null)
                tallGrandChild = this.m_leftChild;
            else if (this.m_rightChild != null)
                tallGrandChild = this.m_rightChild;
            if (tallGrandChild.m_leftChild != null && tallGrandChild.m_rightChild != null)
            {
                if (tallGrandChild.m_leftChild.getHeight() > tallGrandChild.m_rightChild.getHeight())
                    tallGrandChild = tallGrandChild.m_leftChild;
                else
                    tallGrandChild = tallGrandChild.m_rightChild;
            }
            else if (tallGrandChild.m_leftChild != null)
                tallGrandChild = tallGrandChild.m_leftChild;
            else if (tallGrandChild.m_rightChild != null)
                tallGrandChild = tallGrandChild.m_rightChild;
            return tallGrandChild;
        }

        public void Add(TreeKey key, TreeData data)
        {
            int comparison = m_node.getKey().CompareTo(key);
            if (comparison >= 0)
            {
                if (m_leftChild == null)
                {
                    AVLTree newLeftChild = new AVLTree(key, data);
                    this.addLeftChild(newLeftChild);
                    newLeftChild.rebalance();
                }
                else
                {
                    this.m_leftChild.Add(key, data);
                }
            }
            else if (comparison < 0)
            {
                if (m_rightChild == null)
                {
                    AVLTree newRightChild = new AVLTree(key, data);
                    this.addRightChild(newRightChild);
                    newRightChild.rebalance();
                }
                else
                {
                    this.m_rightChild.Add(key, data);
                }
            }
        }

        public string print()
        {
            int height = findDepth();
            int widthOfBottomRow = (int)Math.Pow(2, height - 1);
            int lineLength = widthOfBottomRow * 27 + 4 * (widthOfBottomRow - 1);
            int[][] linePaddings = new int[height][];
            linePaddings[0] = new int[1];
            linePaddings[0][0] = (lineLength - 27) / 2;
            linePaddings[height - 1] = new int[2];
            linePaddings[height - 1][0] = 0;
            linePaddings[height - 1][1] = 4;
            //for (int i = 1; i < widthOfBottomRow;i++ )
            //{
            //    linePaddings[height - 1][i] = 4;
            //}
            for (int i = height - 2; i > 0; i--)
            {
                //int numberOfNodesOnRow = (int)Math.Pow(2, i);
                linePaddings[i] = new int[2];
                linePaddings[i][0] = linePaddings[i + 1][1] + 12;
                linePaddings[i][1] = linePaddings[i][0] * 2 + 3;
                //int amountOfPaddingSoFar = linePaddings[i + 1][0];
                //for (int j = 1;j<numberOfNodesOnRow;j++)
                //{
                //    amountOfPaddingSoFar += 27 + linePaddings[i + 1][j * 2 - 1] + 27 + linePaddings[i + 1][j * 2];
                //    int paddingBetweenNodes = (27 + linePaddings[i + 1][2 * j + 1] + 27) / 2 - 13;
                //    int cumalitivePaddingForThisLineSoFar = 0;
                //    for (int k = 0; k < j;k++ )
                //    {
                //        cumalitivePaddingForThisLineSoFar += linePaddings[i][k] + 27;
                //    }
                //    linePaddings[i][j] = (amountOfPaddingSoFar + paddingBetweenNodes) - cumalitivePaddingForThisLineSoFar;
                //}
            }
            string ret = "";
            AVLTree[] currentRow = new AVLTree[1];
            currentRow[0] = this;
            for (int i = 0; i < height;i++ )
            {
                int numberOfPossibleNodes = (int)Math.Pow(2, i);
                ret += printSpaces(linePaddings[i][0]);
                for (int j = 0; j < currentRow.Length; j++)
                {
                    if (currentRow[j] == null)
                    {
                        ret += "(       ,        ,        )";
                    }
                    else
                    {
                        ret += currentRow[j].m_node.getKey().ToString();
                    }
                    if (j + 1 < currentRow.Length)
                    {
                        ret += printSpaces(linePaddings[i][1]);
                    }
                }
                ret += "\r\n";
                AVLTree[] nextRow = new AVLTree[currentRow.Length * 2];
                for (int j=0;j<currentRow.Length;j++)
                {
                    if (currentRow[j] != null)
                    {
                        nextRow[j * 2] = currentRow[j].m_leftChild;
                        nextRow[j * 2 + 1] = currentRow[j].m_rightChild;
                    }
                }
                currentRow = nextRow;
            }
            return ret;
        }

        private string printSpaces(int numberOfSpaces)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(' ', numberOfSpaces);
            return builder.ToString();
        }

        private int findDepth()
        {
            if (isExternal())
                return 1;
            else
            {
                if (m_leftChild!= null && m_rightChild != null)
                {
                    int leftDepth = m_leftChild.findDepth() + 1;
                    int rightDepth = m_rightChild.findDepth() + 1;
                    return Math.Max(leftDepth, rightDepth);
                }
                else if (m_leftChild != null)
                {
                    return m_leftChild.findDepth() + 1;
                }
                else
                {
                    return m_rightChild.findDepth() + 1;
                }
            }
        }
    }
}
