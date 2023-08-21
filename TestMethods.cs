using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
            Stack<int> result = new();

            if (sourceStack.Count > 0 && sourceStack != null)
            {
                int[] tmp = new int[sourceStack.Count];
                for (int i = sourceStack.Count - 1; i > 0 ; i--)
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
            Dictionary<int, EValueType> result = new();

            if (sourceArr != null && sourceArr.Length > 0)
            {
                for (int i = 0; i < sourceArr.Length; i++) 
                {
                    if (sourceArr[i] % 2 == 0) result.Add(sourceArr[i], EValueType.Two);
                    else if (sourceArr[i] % 3 == 0) result.Add(sourceArr[i], EValueType.Three);
                    else if (sourceArr[i] % 5 == 0) result.Add(sourceArr[i], EValueType.Five);
                    else if (sourceArr[i] % 7 == 0) result.Add(sourceArr[i], EValueType.Seven);
                    else result.Add(sourceArr[i], EValueType.Prime);
                }
            }

            return result;
        }

        internal static int CountDictionaryRegistriesWithValueType(Dictionary<int, EValueType> sourceDict, EValueType type)
        {
            if(sourceDict.Count > 0 && sourceDict != null)
            {
                byte counter = 0;
                foreach (KeyValuePair<int, EValueType> kvp in sourceDict)
                {
                    if(kvp.Value.Equals(type)) counter++;
                }
                return counter;
            }

            return 0;
        }

        internal static Dictionary<int, EValueType> SortDictionaryRegistries(Dictionary<int, EValueType> sourceDict)
        {
            Dictionary<int, EValueType> result = new();

            if (sourceDict.Count > 0 && sourceDict != null)
            {
                int[] tmp = new int[sourceDict.Count];
                int i = 0;
                foreach (KeyValuePair<int, EValueType> kvp in sourceDict)
                {
                    tmp[i] = kvp.Key;
                    i++;
                }
                //
                tmp = BubbleSort(tmp);
                //
                result =  FillDictionaryFromSource(tmp);
            }

            return result;
        }
        internal static int[] BubbleSort(int[] array)
        {
            if(array.Length > 0 && array != null)
            {
                int n = array.Length;
                bool swapped;

                for (int i = 0; i < n - 1; i++)
                {
                    swapped = false;

                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (array[j] > array[j + 1])
                        {
                            // Swap array[j] and array[j + 1]
                            int temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                            swapped = true;
                        }
                    }

                    // If no two elements were swapped by inner loop, then the array is already sorted
                    if (!swapped)
                    {
                        break;
                    }
                }
            }
            return null;
        }
        internal static Queue<Ticket>[] ClassifyTickets(List<Ticket> sourceList)
        {
            Queue<Ticket>[] result = new Queue<Ticket>[3];

            if (sourceList.Count > 0 && sourceList != null)
            {
                Queue<Ticket> payment = new Queue<Ticket>();
                Queue<Ticket> subscription = new Queue<Ticket>();
                Queue<Ticket> cancellation = new Queue<Ticket>();

                for (int i = 0; i < sourceList.Count - 1; i++)
                {
                    switch (sourceList[i].RequestType)
                    {
                        case Ticket.ERequestType.Payment: payment.Enqueue(sourceList[i]); break;
                        case Ticket.ERequestType.Subscription: subscription.Enqueue(sourceList[i]); break;
                        case Ticket.ERequestType.Cancellation: cancellation.Enqueue(sourceList[i]); break;
                    }
                }
                result[0] = payment;
                result[1] = subscription;
                result[2] = cancellation;
            }

            return result;
        }

        internal static bool AddNewTicket(Queue<Ticket> targetQueue, Ticket ticket)
        {
            bool result = false;

            if (ticket.RequestType == targetQueue.ElementAt(0).RequestType)
            {
                targetQueue.Enqueue(ticket);
                result = true;
            }

            return result;
        }        
    }
}