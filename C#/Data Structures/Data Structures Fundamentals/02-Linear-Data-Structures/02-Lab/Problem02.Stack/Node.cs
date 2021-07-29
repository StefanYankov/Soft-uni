namespace Problem02.Stack
{
    public class Node<T>
    {
        public T Element { get; set; }

        public Node<T> Next { get; set; }

        public Node(T element, Node<T> next = null)
        {
            this.Element = element;
            this.Next = next;
        }
    }
}