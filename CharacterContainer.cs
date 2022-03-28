using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGame._1
{
    class CharacterContainer
    {
        private Character[] chars;
        public int Count { get; private set; }
        private int Capacity;

        public CharacterContainer(int capacity = 6)
        {
            this.Capacity = capacity;
            this.chars = new Character[capacity];
        }

        private void EnsureCapacity(int minimumCapacity)
        {
            if(minimumCapacity > this.Capacity)
            {
                Character[] temp = new Character[minimumCapacity];
                for(int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.chars[i];
                }
                this.Capacity = minimumCapacity;
                this.chars = temp;
            }
        }

        public void Add(Character character)
        {
            if(this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.chars[this.Count++] = character;
        }

        public Character Get(int index)
        {
            return this.chars[index];
        }

        public void Sort()
        {
            bool flag = true;
            while (flag)
            {
                flag = false;

                for (int i = 0; i < this.Count - 1; i++)
                {
                    Character a = this.chars[i];
                    Character b = this.chars[i + 1];

                    if (a.CompareTo(b) > 0)
                    {
                        this.chars[i] = b;
                        this.chars[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }

    }
}
