using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDataStructure
{
    public class DoublyLinkedList
    {
        public class LinkNode
        {
            public LinkNode(int value)
            {
                this.Value = value;
            }
            public int Value { get; }

            public LinkNode NextNode { get; set; }
            public LinkNode PreviousNode { get; set; }
        }

    }
}
