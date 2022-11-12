using System.Collections;
namespace queue
{
    class Queue : ArrayList
    {
        public void Enqueue(Object value)
        {
            this.Add(value);
        }

        public Object Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            var removedObject = this[0];
            this.RemoveAt(0);
            return removedObject;

        }
    }

}


