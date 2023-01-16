 public class TreeNode {
     public int val;
     public TreeNode left;
     public TreeNode right;
     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
         this.val = val;
         this.left = left;
         this.right = right;
     }

    //  public static TreeNode? Create(params int?[] data)
    //  {
    //     return Create(data);
    //  }

     public static TreeNode? Create(params int?[] data)
     {
        if (data == null || !data.Any())
        {
            return null;
        }

        var root = new TreeNode(data[0] ?? 0);
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        var index = 0;
        while (queue.Any() && index < data.Length)
        {
            var node = queue.Dequeue();
            if (++index < data.Length && data[index] != null)
            {
                node.left = new TreeNode(data[index] ?? 0);
                queue.Enqueue(node.left);
            }

            if (++index < data.Length && data[index] != null)
            {
                node.right = new TreeNode(data[index] ?? 0);
                queue.Enqueue(node.right);
            }
        }

        return root;
     }
 }