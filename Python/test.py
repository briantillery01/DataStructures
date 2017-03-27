from node import Node
from doublyLinkedList import LinkedList

if __name__ == '__main__':
    node1 = Node(5)
    node2 = Node(7)
    node3 = Node(0)

    dlList = LinkedList()
    dlList.add_front(node1)
    dlList.size()

    dlList.add_end(node2)
    dlList.size()

    dlList.add_at(node3, 1)
    dlList.size()

    dlList.print_forward()
    dlList.print_backward()

    dlList.clear()
    dlList.size()
    
    

