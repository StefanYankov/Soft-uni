namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newNode = new Node<T>(item);

            if (this.Count == 0)
            {
                this.head = this.tail = newNode;
                this.Count++;
                return;
            }

            var oldHead = this.head;
            oldHead.Previous = newNode;

            this.head = newNode;
            this.head.Next = oldHead;
            this.Count++;

        }

        public void AddLast(T item)
        {
            var newNode = new Node<T>(item);
            if (this.Count == 0)
            {
                this.head = this.tail = newNode;
                this.Count++;
                return;
            }

            var oldTail = this.tail;
            oldTail.Next = newNode;

            this.tail = newNode;
            this.tail.Previous = oldTail;
            this.Count++;

        }

        public T GetFirst()
        {
            this.EnsureNotEmpty();
            return this.head.Item;
        }

        public T GetLast()
        {
            this.EnsureNotEmpty();
            return this.tail.Item;
        }

        public T RemoveFirst()
        {
            this.EnsureNotEmpty();
            var oldHead = this.head;
            if (this.Count == 1)
            {
                this.head = this.tail = null;
                this.Count--;
                return oldHead.Item;
            }

            this.head = this.head.Next;
            this.head.Previous = null;
            this.Count--;
            return oldHead.Item;
        }

        public T RemoveLast()
        {
            this.EnsureNotEmpty();
            var oldTail = this.tail;

            if (this.Count == 1)
            {
                this.head = this.tail = null;
                this.Count--;
                return oldTail.Item;
            }

            this.tail = this.tail.Previous;
            this.tail.Next = null;
            this.Count--;
            return oldTail.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.head;
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
            {
                throw new InvalidOperationException();
            }
        }

    }
}