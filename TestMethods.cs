using System.Collections.Generic;

namespace TestProject1
{
    internal class TestMethods
    {
        internal enum EValueType
        {
            Two,
            Three,
            Five,
            Seven,
            Prime
        }

        internal static Stack<int> GetNextGreaterValue(Stack<int> sourceStack)
        {
            Stack<int> result = null;

            if (sourceStack.Count > 0 && sourceStack != null)
            {
                int[] tmp = new int[sourceStack.Count];
                for (int i = sourceStack.Count; i > 0 ; i--)
                {
                    tmp[i] = sourceStack.Pop();
                }

                for (int i = 0; i < sourceStack.Count; i++)
                {
                    if(i == sourceStack.Count - 1)
                    {
                        result.Push(-1);
                    }
                    else
                    {
                        bool gate = false;
                        for (int j = i + 1; j < sourceStack.Count - i; j++)
                        {
                            if (tmp[i] < tmp[j])
                            {
                                result.Push(tmp[j]);
                                gate = true;
                                break;
                            }
                        }
                        if (!gate)
                        {
                            result.Push(-1);
                        }
                    }
                }
            }

            return result;
        }

        internal static Dictionary<int, EValueType> FillDictionaryFromSource(int[] sourceArr)
        {
            Dictionary<int, EValueType> result = null;

            return result;
        }

        internal static int CountDictionaryRegistriesWithValueType(Dictionary<int, EValueType> sourceDict, EValueType type)
        {
            return 0;
        }

        internal static Dictionary<int, EValueType> SortDictionaryRegistries(Dictionary<int, EValueType> sourceDict)
        {
            Dictionary<int, EValueType> result = null;

            return result;
        }

        internal static Queue<Ticket>[] ClassifyTickets(List<Ticket> sourceList)
        {
            Queue<Ticket>[] result = null;

            return result;
        }

        internal static bool AddNewTicket(Queue<Ticket> targetQueue, Ticket ticket)
        {
            bool result = false;

            return result;
        }        
    }
}