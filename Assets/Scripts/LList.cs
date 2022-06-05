using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListNode<T> {
    public T data;
    public ListNode<T> next;

    public ListNode(T x) {
        data = x;
        next = null;
    }
}

public class LList<T> {
    public int count;
    public ListNode<T> head;
    public ListNode<T> tail;
    

    public ListNode<T> Tail { get => tail; }
    
    
        public LList() {
            head = null;
            count = 0;
            
        }

        public void AddFront(T data) {
            ListNode<T> node = new ListNode<T>(data);
            if (count == 0) {
                tail = node;
                head = node;    
                count++;
                return;
            }
            node.next = head;
            head = node;
            count++;
        }

        public void AddAfter(T data, T addAfterthis) {
            ListNode <T> node = new ListNode <T>(data);
            if (count == 0) {
                AddLast(data);
            }
            ListNode <T> currentNode = head;
            
            while (currentNode != null) {
                if (currentNode.data.Equals(addAfterthis)) {
                    ListNode <T> saveNode = currentNode.next;
                    currentNode.next = node;
                    node.next = saveNode;
                    
                    if (currentNode.Equals(tail)) {
                        tail = node;
                    }
                }
                
                currentNode = currentNode.next;
            }
            count++;
        }

        public void AddLast(T data) {
            ListNode <T> node = new ListNode <T>(data);
            if (count == 0) {
                head = node;
                tail = node;
                count++;
                return;
            }
            tail.next = node;
            tail = node;
            count++;
        }

        public void PrintList() {
            ListNode<T> runner = head;
            while (runner != null) {
                Debug.Log(runner.data);
                runner = runner.next;
            }
        }
    
}
