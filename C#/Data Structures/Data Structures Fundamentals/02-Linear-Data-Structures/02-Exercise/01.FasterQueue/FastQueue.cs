namespace Problem01.FasterQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class FastQueue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;
        private Node<T> _tail;
        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var node = this._head;
            while (node != null)
            {
                if (node.Item.Equals(item))
                {
                    return true;
                }

                node = node.Next;
            }
            return false;
        }

        public T Dequeue()
        {
            this.EnsureNotEmpty();
            var currentHead = this._head;
            this._head = this._head.Next;
            this.Count--;

            return currentHead.Item;
        }

        public void Enqueue(T item)
        {
            var newNode = new Node<T>(item, null);

            if (this.Count == 0)
            {
                //this._tail = newNode;
                //this._head = this._tail;
                
                this._head = this._tail = newNode;
                this.Count++;
                return;
            }

            this._tail.Next = newNode;
            this._tail = this._tail.Next;
            this.Count++;
        }

        public T Peek()
        {
            this.EnsureNotEmpty();
            return this._head.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this._head;
            while (node != null)
            {
                yield return node.Item;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
                throw new InvalidOperationException();
        }
    }
}