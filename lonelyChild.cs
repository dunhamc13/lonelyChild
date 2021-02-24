/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     TreeNode *left;
 *     TreeNode *right;
 *     TreeNode() : val(0), left(nullptr), right(nullptr) {}
 *     TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
 *     TreeNode(int x, TreeNode *left, TreeNode *right) : val(x), left(left), right(right) {}
 * };
 */
class Solution {
public:
    
    
    /** 
      * Problem : getLonelyNodes : algortithm that searches a binary tree for 
      * single children nodes.
      * Inputs: Binary Tree, Pointer to the root 
      * Outputs : Vector <int> : contains all values of 'lonelyNodes' in any order
      * Constraints : num Nodes in tree is range{1,1000}
      *             : nod Values is range {1, 10^6}
      * Test Cases : root = {1,2,3,null,4} : returns 4
    **/
    vector<int> getLonelyNodes(TreeNode* root) {
        //first create a vector for the result
        vector<int> res;
        
        //then call depth first search
        dfs(root, res);
        return res;
    }
    
private:
    
    /** dfs is a depth first search
      * Inputs : TreeNode *root -> pointer to a root maybe
      *        : vector<int> that keeps lonely child values
      * No output
    **/
    void dfs(TreeNode* root, vector<int> &res) {
        //first is the root emtpy?
        if (!root) return;
        
        //if the node is an innner node, it has both children : recurseive call both sides
        if ((root->left) && (root->right)) {
            dfs(root->left, res);
            dfs(root->right, res);
            return;
        }
        
        //Must not have both children, but it has a left child : recursion on left
        if (root->left) {
            res.push_back(root->left->val);        
            dfs(root->left, res);
        }
        
        //Must not have both or left, but has right child : recursion on right
        if (root->right) {
            res.push_back(root->right->val);        
            dfs(root->right, res);            
        }                
    }    
};
