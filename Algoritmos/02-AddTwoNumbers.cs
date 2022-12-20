using System;

namespace AddTwoNumbers
{
	public class LinkedList
	{
        private ListNode head;
        private ListNode current;

        public LinkedList()
        {
            head = new ListNode();
            head.next = null;
        }
        public class ListNode
		{
			public int val;
			public ListNode next;
			public ListNode(int val = 0, ListNode next = null)
			{
				this.val = val;
				this.next = next;
			}
		}

        public void AddNode(int pDato)
        {
            current = head;
            //Recorrer hasta encontrar el final de la lista

            while (current.next != null)
            {
                //Avanzar al siguiente nodo
                current = current.next;
            }
            //Crear un nuevo nodo
            ListNode temp = new ListNode();

            //Insertamos el dato
            temp.val = pDato;

            //Finalizamos correctamente
            temp.next = null;

            //Insertamos el nuevo nodo al final de la lista, ligar el último nodo encontrado con el nuevo nodo
            current.next = temp;
        }

        public void Transverse()
        {
            //Trabajo al inicio
            current= head;

            //Recorrer hasta encontrar el final de la lista
            while (current.next != null)
            {
                //Avanzar al siguiente nodo
                current = current.next;
                //Obtener el siguiente nodo y lo mostramos
                int d = current.val;

                Console.Write("[{0}] ", d);
            }
            Console.WriteLine();
        }
		public ListNode AddTwoNumbers(ListNode l1, ListNode l2) 
    	{
            var dummy = new ListNode(-1);
            var current = dummy;

            var carry = 0;
            while (l1 != null || l2 != null)
            {
                var value1 = l1 == null ? 0 : l1.val;
                var value2 = l2 == null ? 0 : l2.val;

                var sum = value1 + value2 + carry;
                carry = sum / 10;
                sum %= 10;
                current.next = new ListNode(sum);

                current = current.next;
                l1 = l1 == null ? null : l1.next;
                l2 = l2 == null ? null : l2.next;
            }

            if (carry != 0)
                current.next = new ListNode(carry);

            return dummy.next;
        }

		public static void Main(string[] args)
		{
			//Initialize linked list
            LinkedList list1 = new LinkedList();
            LinkedList list2 = new LinkedList();

            //Add nodes to linked list
            list1.AddNode(2);
            list1.AddNode(4);
            list1.AddNode(3);

            list2.AddNode(5);
            list2.AddNode(6);
            list2.AddNode(4);

            //Print linked list
            Console.Write("Input: l1 = "); 
            list1.Transverse();
            Console.Write("Input: l2 = ");
            list2.Transverse();

            Console.WriteLine();

            //Add two numbers
            LinkedList list3 = new LinkedList();

            var result = list3.AddTwoNumbers(list1.head, list2.head);
            list3.head = result;

            //Print linked list
            Console.Write("Output: l3 = ");
            list3.Transverse();

        
        }
	}
}
