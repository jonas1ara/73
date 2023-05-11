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
            current = head;

            //Recorrer hasta encontrar el final de la lista
            while (current.next != null)
            {
                current = current.next;
                //Obtener el siguiente nodo y mostramos su valor
                int d = current.val;

                Console.Write("[{0}] ", d);
            }
            Console.WriteLine();
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            // Creamos un nodo ficticio para el resultado
            var dummy = new ListNode();
            // Creamos un puntero para el nodo actual
            var current = dummy;

            // Inicializamos la variable carry en 0
            var carry = 0;
            // Mientras l1 o l2 no sean nulos
            while (l1 != null || l2 != null)
            {
                //El operador ternario en C# es una expresión condicional que evalúa una expresión booleana y devuelve el resultado de una de las dos expresiones, dependiendo de si la expresión booleana se evalúa como verdadera o falsa
                //variable = (condición) ? expresión1 : expresión2;
                //En este caso si l1 es nulo, entonces el valor de value1 será 0, de lo contrario será el valor de l1.val
                var value1 = l1 == null ? 0 : l1.val;
                var value2 = l2 == null ? 0 : l2.val;

                // Sumamos los valores y el carry
                var sum = value1 + value2 + carry;
                // Actualizamos el carry
                carry = sum / 10;
                // Obtenemos el valor del resultado
                sum %= 10;
                
                // Creamos un nuevo nodo con el valor del resultado
                current.next = new ListNode(sum);
                // Actualizamos el puntero al nodo actual
                current = current.next;

                // Actualizamos los punteros de l1 y l2
                // En este caso si l1 es nulo, entonces el valor de l1 será nulo, de lo contrario será el valor de l1.next y asi para l2
                l1 = l1 == null ? null : l1.next;
                l2 = l2 == null ? null : l2.next;
            }

            // Si carry no es cero, creamos un nuevo nodo con el valor de carry
            if (carry != 0)
                current.next = new ListNode(carry);

            // Devolvemos el siguiente nodo después del nodo ficticio
            return dummy.next;
        }

        public static void Main(string[] args)
        {
            //Inicializar las listas
            LinkedList list1 = new LinkedList();
            LinkedList list2 = new LinkedList();

            //Adherir nodos a la primera lista
            list1.AddNode(2);
            list1.AddNode(4);
            list1.AddNode(3);

            //Adherir nodos a la segunda lista
            list2.AddNode(5);
            list2.AddNode(6);
            list2.AddNode(4);

            //Impresión de las listas
            Console.Write("Input: l1 = ");
            list1.Transverse();
            Console.Write("Input: l2 = ");
            list2.Transverse();

            Console.WriteLine();

            //Crear una nueva lista para almacenar el resultado
            LinkedList list3 = new LinkedList();

            var result = list3.AddTwoNumbers(list1.head, list2.head);
            list3.head = result;

            //Impresión de la lista resultante
            Console.Write("Output: l3 = ");
            list3.Transverse();
        }
    }
}
