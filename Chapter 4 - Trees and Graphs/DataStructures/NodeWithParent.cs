namespace Chapter_4.DataStructures
{
    public class NodeWithParent
    {
        public int data;
        public NodeWithParent left;
        public NodeWithParent right;
        public NodeWithParent parent;

        public NodeWithParent(int data)
        {
            this.data = data;
        }
    }
}
