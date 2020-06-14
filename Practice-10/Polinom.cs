using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_10
{
    public class Polinom
    {
        public Element[] polinom;
        public int Count; 
        public Polinom()
        {
            polinom = new Element[0];
            Count = 0;
        }
        public Polinom(Polinom p)
        {
            polinom = p.polinom;
            Count = p.Count;
        }
        public void Add(Element element)
        {
            if (!(element.coefficient == 0))
            {
                int pos = -1;
                for (int i = 0; i < Count; i++)
                {
                    if (element.exponent == polinom[i].exponent)
                        pos = i;
                }
                if (pos != -1)
                    polinom[pos].coefficient += element.coefficient;
                else
                {
                    Polinom helper = new Polinom(this);
                    this.polinom = new Element[Count + 1];
                    for (int i = 0; i < Count; i++)
                    {
                        this.polinom[i] = helper.polinom[i];
                    }
                    this.polinom[Count] = element;
                    Count++;
                }
            }
        }
        public void Sorting()
        {
            int PosofMin;
            Element helper = new Element(0, 0);
            for (int i = 1; i < this.Count - 1; i++)
            {
                PosofMin = i - 1;
                for (int j = i; j < this.Count; j++)
                {
                    if (this.polinom[j].exponent < this.polinom[PosofMin].exponent)
                    {
                        PosofMin = j;
                    }
                }
                if (PosofMin != i - 1)
                {
                    helper.exponent = this.polinom[i - 1].exponent;
                    helper.coefficient = this.polinom[i - 1].coefficient;
                    this.polinom[i - 1].exponent = this.polinom[PosofMin].exponent;
                    this.polinom[i - 1].coefficient = this.polinom[PosofMin].coefficient;
                    this.polinom[PosofMin].exponent = helper.exponent;
                    this.polinom[PosofMin].coefficient = helper.coefficient;
                }
            }
        }
    }
}
