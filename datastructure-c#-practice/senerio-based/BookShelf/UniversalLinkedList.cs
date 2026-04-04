    public class UniversalLinkedList
    {
        public class Node
        {
            private object data;
            private Node next;
            private Node prev;

            public Node(object data)
            {
                this.data = data;
                next = null;
                prev = null;
            }

            public object GetData() => data;
            public void SetData(object data) => this.data = data;

            public Node GetNext() => next;
            public void SetNext(Node next) => this.next = next;

            public Node GetPrev() => prev;
            public void SetPrev(Node prev) => this.prev = prev;
        }

        private Node head;
        private Node tail;

        public Node GetHead() => head;

        // Singly / Doubly append
        public void AddLast(object data)
        {
            Node newNode = new Node(data);

            if (head == null)
            {
                head = tail = newNode;
                return;
            }

            tail.SetNext(newNode);
            newNode.SetPrev(tail);
            tail = newNode;
        }

        // Stack / Queue style insert
        public void AddFirst(object data)
        {
            Node newNode = new Node(data);

            if (head == null)
            {
                head = tail = newNode;
                return;
            }

            newNode.SetNext(head);
            head.SetPrev(newNode);
            head = newNode;
        }

        // Remove from front (Queue / Stack)
        public object RemoveFirst()
        {
            if (head == null)
                return null;

            object data = head.GetData();
            head = head.GetNext();

            if (head != null)
                head.SetPrev(null);
            else
                tail = null;

            return data;
        }

        // Remove from end
        public object RemoveLast()
        {
            if (tail == null)
                return null;

            object data = tail.GetData();
            tail = tail.GetPrev();

            if (tail != null)
                tail.SetNext(null);
            else
                head = null;

            return data;
        }

        public bool IsEmpty()
        {
            return head == null;
        }
    }

