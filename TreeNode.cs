using System;
using System.Collections.Generic;
using System.Text;

namespace XiangqiProject
{
    class TreeNode
    {
        int id;
        int parentId;
        int data = -1000000000;
        int level;
        List<TreeNode> children = new List<TreeNode>();

        public TreeNode()
        {

        }

        public TreeNode(int id, int data, int parentId, int level)
        {
            this.id = id;
            this.parentId = parentId;
            this.data = data;
            this.level = level;
        }

        public TreeNode(int id, TreeNode parent, int level)
        {
            this.id = id;
            this.parentId = parent.GetId();
            this.level = level;

        }

        public TreeNode(int id, int level, int parenid)
        {
            this.id = id;
            this.level = level;

        }

        public TreeNode(int id, int data, TreeNode parent, int level)
        {
            this.id = id;
            this.parentId = parent.GetId();
            this.data = data;
            this.level = level;
        }

        public int GetParentId()
        {
            return parentId;
        }

        public void SetParentId(int parentId)
        {
            this.parentId = parentId;
        }

        public int GetData()
        {
            return data;
        }

        public void SetData(int data)
        {
            this.data = data;
        }

        public int GetId()
        {
            return id;
        }

        public void SetId(int id)
        {
            this.id = id;
        }


        public void AddChildren(TreeNode node)
        {
            children.Add(node);
        }

        public int Getlevel()
        {
            return this.level;
        }

        public List<TreeNode> GetChildren()
        {
            return children;
        }

        public void SetChildren(TreeNode children)
        {
            this.children.Add(children);
        }

    }
}
