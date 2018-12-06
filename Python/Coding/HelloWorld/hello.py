#! python
#import sys
#sys.stdout.write("hello from Python %s\n" % (sys.version,))

x = "this is a variable"
print("hello world")
print(x)

print("Dir of path")
print("%s print x now." % x)
print("print x now: %s " % x)

myVar = ("dir C:/Users/Mars/source/MyownCode/Python/Coding/HelloWorld/my_html_file.html")
myVar

myVideoNo = 0
MyVideoStr = "https://youtu.be/-F6PDE3idKs?t="

#myVar1 = "<html><head><title>Look at this</title></head><body><h2>Hello World</h2><a href='http://www.hipstercode.com'>Click Me</a></body></html>"
myVar1 = "<html><head><title>Look at this</title></head><body><h2>Hello World</h2><a href=' " + MyVideoStr + str(myVideoNo) + "'>Click Me</a></body></html>"

myVar1 = """
    <html>
        <head>
            <title>Look at this</title>
        </head>
        <body>
            <h2>Hello World</h2>
            <a href=' 
        """

myVar2 = MyVideoStr + str(myVideoNo)

myVar3 = """
            '>Click Me</a>
        </body>
    </html>
    """

myVar1 = '''
    <html>
        <head>
            <title>Look at this</title>
        </head>
        <body>
            <h2>Hello World</h2>
            <a href=' 
        '''

myVar2 = MyVideoStr + str(myVideoNo)

myVar3 = '''
            '>Click Me</a>
        </body>
    </html>
    '''

myVar = myVar1
myVar = myVar1 + myVar2 + myVar3


#https://youtu.be/-F6PDE3idKs?t=0
#file:///C:/Users/Mars/source/MyownCode/Python/Coding/HelloWorld/%22%20+%20MyVideoStr%20+%20str(myVideoNo)%20+%20%22



my_html_file = open("C:/Users/Mars/source/MyownCode/Python/Coding/HelloWorld/my_html_file.html", "w")

my_html_file.write(myVar)
my_html_file.close()


myList = []
myList2 = ["orange", "apple", "bannana", 1, myList]
print(len(myList2))

print(myList2)

#Remove the orange 
print("Now pop")
myList2.pop()
print(myList2)


#should print organe as pop does not remove just picks it up, i.e like an index
myListVar = myList2.pop(0)
print("Now using indexes: 1st pop")
print(myListVar)


myListVar = myList2.pop(0)
print("2nd pop")
print(myListVar)

myListVar = myList2.pop(1)
print("3rd pop")
print(myListVar)

print("Done")
print(myList2)

#===========================
myList2 = ["orange", "apple", "bannana", 1, myList]
print(myList2)

print("Zero element")
print(myList2[0])

print("First element")
print(myList2[1])


print("Insert after First element")
myList2.insert(1, "myFriut")
print(myList2)

print("Remove an element by name")
myList2.remove("myFriut")
print(myList2)

print("again Insert after First element")
myList2.insert(1, "shrimp")
print(myList2)

#Remove won't remove by no
print("Remove an element by no")
#myList2.remove(0)
print(myList2)

#myList
myList2.remove(myList)
print("Remove Other list named myList from list")
print(myList2)

myList3 = ["orange", "apple", "bannana"]
myList3.extend("7")
print("Extend list i.e add to the end of it")
print(myList3)
