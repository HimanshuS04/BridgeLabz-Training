class UserNode
{
    public int id;
    public string name;
    public UserNode next;
}

class SocialMedia
{
    UserNode head;

    public void AddUser(int id, string name)
    {
        UserNode node = new UserNode { id = id, name = name };
        node.next = head;
        head = node;
    }

    public void SearchUser(int id)
    {
        UserNode temp = head;
        while (temp != null)
        {
            if (temp.id == id)
            {
                Console.WriteLine(temp.name);
                return;
            }
            temp = temp.next;
        }
    }
}
