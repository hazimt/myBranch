
typedef struct elementT
{
	struct elementT *next;
	void *data;
	int mydata;
} element;

typedef struct nodeT {
	struct nodeT *left;
	struct nodeT *right;
	int value;
} node;

node * root;
/*class Stack
{
public:
Stack();
~Stack();

void Push(void *data);
void *Pop();
//protected:
//Element struct needed only internally
typedef struct elementT {
struct elementT *next;
void *data;
} element;

element *firstEl;
};

Stack::Stack()
{
element *firstEL=NULL;
return;
}

Stack::~Stack() {
element *next;
while (firstEl) {
next = firstEl->next;
delete firstEl;
firstEl = next;
}
return;
}

volid Stack::Push(void *data) {
//Allocation error will throw exception
element *element = new element;
element ->data = data;
element->next- firstEl;
firstEl = element;
return;
}

volid *Stack::Pop() {
element *popElement = firstEl;
void *data;

//Assume StackError exception calss is defined elsewhere
if (firstEl->data;
firstEl = firstEl->next;
delete popElement;
return data;
}
*/