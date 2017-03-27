import node

class LinkedList:
    def __init__(self):
        self.length = 0
        self.head = None
        self.tail = None

    def size(self):
        print(self.length)

    def add_front(self, node):
        if (self.head == None):
            self.head = node
            self.tail = node
            self.length += 1
        else:
            node.next(self.head)
            self.head = node
            self.length += 1

    def add_end(self, node):
        if (self.tail == None):
            self.head = node
            self.tail= node
            self.length += 1
        else:
            node.prev(self.tail)
            self.tail = node
            self.length += 1

    def add_at(self, node, index):
        if (index < 0):
            print("Error! Index less than 0.")
        elif (index >= self.length):
            print("Error! Index out of bounds.")
        elif (index == 0):
            self.add_front(node)
        elif (index == (self.length-1)):
            self.add_end(node)
        else:
            currentIndex = 0
            currentNode = self.head
            while(currentIndex != index):
                currentNode = currentNode.next()
                currentIndex += 1
            node.next(currentNode)
            node.prev(currentNode.prev())
            currentNode.prev(node)

    def clear(self):
        currentNode = self.head
        while(currentNode != None):
            tmpNode = currentNode
            currentNode = currentNode.next()
            tmpNode.prev(None)
            tmpNode.next(None)
            tmpNode = None
        self.length = 0
        
    def print_forward(self):
        print("[")
        if (self.head != None):
            self.head.print_forward()
        print("]")

    def print_backward(self):
        print("[")
        if (self.tail != None):
            self.tail.print_backward()
        print("]")
