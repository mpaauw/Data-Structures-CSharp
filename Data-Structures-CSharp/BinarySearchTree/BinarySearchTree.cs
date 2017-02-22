﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_CSharp.BinarySearchTree
{
    /// <summary>
    /// Represents a Binary Search Tree data structure.
    /// </summary>
    /// <typeparam name="T">Underlying data type represented within the class object.</typeparam>
    public class BinarySearchTree<T>
    {
        private BinarySearchTreeNode<T> root;

        private int size;

        /// <summary>
        /// Default constructor.
        /// Assigns initial root of tree to an input parameter and increments the size of the tree by 1.
        /// </summary>
        /// <param name="input">Item to be set as the initial root of the tree.</param>
        public BinarySearchTree(T input)
        {
            root = new BinarySearchTreeNode<T>(input);
            this.size++;
        }

        /// <summary>
        /// Returns the current number of elements within the tree.
        /// </summary>
        /// <returns>Returns an int value representing the current size of the tree.</returns>
        public int getSize()
        {
            return this.size;
        }

        /// <summary>
        /// Determines whether or not a specified value exists within the tree.
        /// Uses a wrapper method in order to achieve a recursive search.
        /// </summary>
        /// <param name="input">Item to be searched for within the tree.</param>
        /// <returns>Returns true if the tree contains the search term, false if otherwise.</returns>
        public bool search(IComparable input)
        {
            BinarySearchTreeNode<T> temp = this.root;
            return search(input, temp);
        }
        private bool search(IComparable input, BinarySearchTreeNode<T> node)
        {
            if(node == null)
            {
                return false;
            }
            else if (node.data.Equals(input))
            {
                return true;
            }
            else if(input.CompareTo(node.data) > 0)
            {
                return search(input, node.right);
            }
            else
            {
                return search(input, node.left);
            }
        }

        /// <summary>
        /// Finds the smallest value within the tree.
        /// </summary>
        /// <returns>Returns an object of type T representing the smallest value within the tree.</returns>
        public T findMinimum()
        {
            BinarySearchTreeNode<T> temp = this.root;
            return findMinimum(temp);
        }
        private T findMinimum(BinarySearchTreeNode<T> node)
        {
            if(node.left == null)
            {
                return node.data;
            }
            return findMinimum(node.left);
        }

        /// <summary>
        /// Finds the largest value within the tree.
        /// </summary>
        /// <returns>REturns an object of type T representing the largest value within the tree.</returns>
        public T findMaximum()
        {
            BinarySearchTreeNode<T> temp = this.root;
            return findMaximum(temp);
        }
        private T findMaximum(BinarySearchTreeNode<T> node)
        {
            if(node.right == null)
            {
                return node.data;
            }
            return findMaximum(node.right);
        }

        /// <summary>
        /// Traverses the tree using an Inorder traversal pattern.
        /// </summary>
        /// <returns>Returns an array of BinarySearchTreeNode objects of type T ordered in the sequence they were encountered during tree traversal.</returns>
        public T[] traverse()
        {
            BinarySearchTreeNode<T> temp = this.root;
            return traverse(new List<T>(), temp).ToArray();
        }
        private List<T> traverse(List<T> order, BinarySearchTreeNode<T> node)
        {
            if(node != null)
            {
                traverse(order, node.left);
                order.Add(node.data);
                traverse(order, node.right);
            }
            return order;
        }

        /// <summary>
        /// Recursively inserts a value into the tree at an appropriate spot given the rules of a Binary Search Tree.
        /// </summary>
        /// <param name="input">Item to be passed and added to the tree; declared as an IComparable type in order to provide comparisons between the key values of other nodes within the tree.</param>
        public void insert(IComparable input)
        {
            this.root = insert(input, this.root, null);
        }
        private BinarySearchTreeNode<T> insert(IComparable input, BinarySearchTreeNode<T> node, BinarySearchTreeNode<T> parent)
        {
            if (node == null)
            {
                node = new BinarySearchTreeNode<T>((T)input);
                node.parent = parent;
                this.size++;
            }
            else if (input.CompareTo(node.data) < 0)
            {
                node.left = insert(input, node.left, node);
            }
            else
            {
                node.right = insert(input, node.right, node);
            }
            return node;
        }
        
        /// <summary>
        /// Recursively deletes the first occurence of a value from the tree, then decrements the size of the tree by 1.
        /// </summary>
        /// <param name="input">Item to be searched for and removed from the tree; declared as an IComparable type in order to provide comparisons between the key values of other nodes.</param>
        public void delete(IComparable input)
        {
            this.root = delete(input, this.root);
        }   
        private BinarySearchTreeNode<T> delete(IComparable input, BinarySearchTreeNode<T> node)
        {
            if(node == null)
            {
                return node;
            }
            if(input.CompareTo(node.data) < 0)
            {
                node.left = delete(input, node.left);
            }
            else if(input.CompareTo(node.data) > 0)
            {
                node.right = delete(input, node.right);
            }
            else if(node.left != null & node.right != null)
            {
                node.data = findMinimum(node.right);
                node.right = delete((IComparable)node.data, node.right);
            }
            else
            {
                node = (node.left != null) ? node.left : node.right;
                this.size--;
            }
            return node;
        }  
    }
}
