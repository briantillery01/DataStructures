class Node:
    def __init__(self, cargo=None, next=None, prev=None):
        self.cargo = cargo
        self.next = next
        self.prev = prev

    def next(self):
        return self.next

    def next(self, node):
        self.next = node

    def prev(self):
        return self.prev

    def prev(self, node):
        self.prev = node
        
    def __str__(self):
        return str(self.cargo)

    def print_forward(self):
        print(self.cargo)
        if(self.next != None):
            tail = self.next
            tail.print_forward()
            
    def print_backward(self):
        if (self.next != None):
            tail = self.next
            tail.print_backward()
        print(self.cargo)
