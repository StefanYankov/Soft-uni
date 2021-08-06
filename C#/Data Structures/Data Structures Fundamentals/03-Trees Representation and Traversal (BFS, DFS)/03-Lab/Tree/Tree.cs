namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;

        public Tree(T value)
        {
            this.Value = value;
            this.Parent = null;
            this._children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.Parent = this;
                this._children.Add(child);
            }
        }

        public T Value { get; private set; }
        public Tree<T> Parent { get; private set; }
        public IReadOnlyCollection<Tree<T>> Children => this._children.AsReadOnly();

        private bool IsRootDeleted { get; set; }

        public ICollection<T> OrderBfs()
        {
            ICollection<T> resut = new List<T>();
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subTree = queue.Dequeue();
                resut.Add(subTree.Value);

                foreach (var child in subTree.Children)
                {
                    queue.Enqueue(child);
                }
            }
            return resut;

        }

        public ICollection<T> OrderDfs()
        {
            var result = new List<T>();
            this.RecursionDfs(this, result);
            // return this.OrderDfsWithStack();
            return result;
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var searchedNode = this.FindBfs(parentKey);
            this.CheckEmptyNode(searchedNode);
            searchedNode._children.Add(child);

        }

        public void RemoveNode(T nodeKey)
        {
            var searchedNode = this.FindBfs(nodeKey);

            this.CheckEmptyNode(searchedNode);

            foreach (var child in searchedNode.Children)
            {
                child.Parent = null;
            }

            searchedNode._children.Clear();

            var parentNode = searchedNode.Parent;

            if (parentNode == null)
            {
                this.IsRootDeleted = true;
            }
            else
            {
                parentNode._children.Remove(searchedNode);
            }

            searchedNode.Value = default(T);

        }

        public void Swap(T firstKey, T secondKey)
        {
            var firstNode = this.FindBfs(firstKey);
            var secondNode = this.FindBfs(secondKey);
            this.CheckEmptyNode(firstNode);
            this.CheckEmptyNode(secondNode);

            var firstParent = firstNode.Parent;
            var secondParent = secondNode.Parent;

            if (firstParent == null)
            {
                SwapRoot(secondNode);
                return;
            }

            if (secondParent == null)
            {
                SwapRoot(firstNode);
                return;
            }



            firstNode.Parent = secondParent;
            secondNode.Parent = firstParent;

            int indexOfFirst = firstParent._children.IndexOf(firstNode);
            int indexOfSecond = secondParent._children.IndexOf(secondNode);

            firstParent._children[indexOfFirst] = secondNode;
            secondParent._children[indexOfSecond] = firstNode;
        }

        private void SwapRoot(Tree<T> secondNode)
        {
            this.Value = secondNode.Value;
            this._children.Clear();
            foreach (var child in secondNode.Children)
            {
                this._children.Add(child);
            }
        }

        private void RecursionDfs(Tree<T> subtree, List<T> result)
        {
            foreach (var child in subtree.Children)
            {
                this.RecursionDfs(child, result);
            }
            result.Add(subtree.Value);
        }
        // Stack implementation
        private ICollection<T> OrderDfsWithStack()
        {
            var result = new Stack<T>();
            var toTraverse = new Stack<Tree<T>>();

            toTraverse.Push(this);

            while (toTraverse.Count > 0)
            {
                var subTree = toTraverse.Pop();

                foreach (var child in subTree.Children)
                {
                    toTraverse.Push(child);
                }

                result.Push(subTree.Value);
            }

            return new List<T>(result);
        }

        private Tree<T> FindBfs(T value)
        {
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subTree = queue.Dequeue();

                if (subTree.Value.Equals(value))
                {
                    return subTree;
                }

                foreach (var child in subTree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        private Tree<T> FindDfs(T value, Tree<T> subTree)
        {
            foreach (var child  in subTree.Children)
            {
                Tree<T> current = this.FindDfs(value, child);

                if (current != null && current.Value.Equals(value))
                {
                    return current;
                }
            }

            if (subTree.Value.Equals(value))
            {
                return subTree;
            }

            return null;
        }

        private void CheckEmptyNode(Tree<T> parentSubTree)
        {
            if (parentSubTree == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
