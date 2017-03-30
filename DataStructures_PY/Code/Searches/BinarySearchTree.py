class BinarySearchTree(object):
    """Public class implementation of the binary search tree data structure"""

    __root = None

    def __init__(self):
      __root = None

    def MakeEmpty(self):
      __root = None

    def IsEmpty(self):
      return __root == None

    def Contains(self, x):
      return __Contains(x, __root)

    def FindMin(self):
      if(IsEmpty()):
        raise Exception('Cannot find minimum value of empty tree')
      return FindMin(__root).GetElement()

    def FindMax(self):
      if(IsEmpty()):
        raise Exception('Cannot find maximum value of empty tree')
      return FindMax(__root).GetElement()

    def Insert(self, x):
      __root = Insert(x, __root)

    def Remove(self, x):
      __root = Remove(x, __root)

    def PrintTree(self):
      Print('')

    def __Compare(self, x, y):
      if(x < y):
        return -1
      elif(x == y):
        return 0
      else:
        return 1

    def __Contains(self, x, subTree):
      if(subTree == None):                        #end of subtree
        return False

      compareResult = __Compare(x, subTree.GetElement())
      if(compareResult < 0):
        return __Contains(x, subTree.GetLeft())   #search left subtree
      elif(compareResult > 0):
        return __Contains(x, subTree.GetRight())  #search right subtree
      else:
        return True                               #match found

    class BinaryNode(object):
      """Public class implementation of the binary search tree node data structure."""
      __element = None
      __left = None
      __right = None

      def __init__(self, element):
        self.__element = element
        self.__left = None
        self.__right = None

      def __init__(self, element, left, right):
        self.__element = element
        self.__left = left
        self.__right = right

      #---------- GETTERS ----------
      def GetElement(self):
        return self.__element

      def GetLeft(self):
        return self.__left

      def GetRight(self):
        return self.__right

      #---------- SETTERS ----------
      def SetElement(self, value):
        self.__element = value
    
      def SetLeft(self, binaryNode):
        self.__left = binaryNode

      def SetRight(self, binaryNode):
        self.__right = binaryNode

