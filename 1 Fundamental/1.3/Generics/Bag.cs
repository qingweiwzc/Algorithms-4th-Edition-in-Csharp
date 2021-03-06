﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Generics
{
    /// <summary>
    /// 背包类。
    /// </summary>
    /// <typeparam name="Item">背包中存放的元素类型。</typeparam>
    public class Bag<Item> : IEnumerable<Item>
    {
        private Node<Item> first;
        private int count;

        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public Bag()
        {
            this.first = null;
            this.count = 0;
        }

        /// <summary>
        /// 背包是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return this.first == null;
        }

        /// <summary>
        /// 返回背包中元素的数量。
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return this.count;
        }

        /// <summary>
        /// 向背包中添加一个元素。
        /// </summary>
        /// <param name="item">要添加的元素。</param>
        public void Add(Item item)
        {
            Node<Item> oldFirst = this.first;
            this.first = new Node<Item>();
            this.first.item = item;
            this.first.next = oldFirst;
            this.count++;
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return new BagEnumerator(this.first);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class BagEnumerator : IEnumerator<Item>
        {
            private Node<Item> current;
            private Node<Item> first;

            Item IEnumerator<Item>.Current => this.current.item;

            object IEnumerator.Current => this.current.item;

            public BagEnumerator(Node<Item> first)
            {
                this.current = new Node<Item>();
                this.current.next = first;
                this.first = this.current;
            }

            void IDisposable.Dispose()
            {
                this.current = null;
                this.first = null;
                return;
            }

            bool IEnumerator.MoveNext()
            {
                if (this.current.next == null)
                    return false;

                Item item = this.current.item;
                this.current = this.current.next;
                return true;
            }

            void IEnumerator.Reset()
            {
                this.current = this.first;
            }
        }
    }


}
