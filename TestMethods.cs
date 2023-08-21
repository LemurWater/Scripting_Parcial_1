using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
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

            if(sourceStack.Count > 0 && sourceStack != null)
            {
                int[] tmp = new int[sourceStack.Count];

                for (int i = sourceStack.Count; i > 0; i--)
                {
                    tmp[i-1] = sourceStack.Pop();
                }

                for (int i = 0; i < tmp.Length; i++)
                {
                    if(i == tmp.Length - 1)
                    {
                        result.Push(-1);
                        break;
                    }

                    bool gate = false;
                    for (int j = i+1; j < tmp.Length; j++)
                    {
                        if (tmp[i] < tmp[j])
                        {
                            result.Push(tmp[j]);
                            gate = true;
                            break;
                        }
                    }
                    if (!gate) result.Push(-1);
                }
            }
            else result.Push(-1);

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
                int[] sorted = new int[sourceDict.Count];
                int i = 0;
                foreach (KeyValuePair<int, EValueType> kvp in sourceDict)
                {
                    tmp[i] = kvp.Key;
                    i++;
                }
                tmp = BubbleSort(tmp);
                i = 0;
                for (int j = tmp.Length - 1; j >= 0; j--)
                {
                    sorted[j] = tmp[i];
                    i++;
                }
                result = FillDictionaryFromSource(sorted);
            }
            else result.Add(1, EValueType.Prime);

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
            return array;
        }
        internal static Queue<Ticket>[] ClassifyTickets(List<Ticket> sourceList)
        {
            Queue<Ticket>[] result = new Queue<Ticket>[3];

            if (sourceList.Count > 0 && sourceList != null)
            {
                Queue<Ticket> payments = new();
                Queue<Ticket> subscriptions = new();
                Queue<Ticket> cancellations = new();

                List<Ticket> l_payment = new();
                List<Ticket> l_subscription = new();
                List<Ticket> l_cancellation = new();
                foreach (Ticket t in sourceList)
                {
                    switch (t.RequestType)
                    {
                        case Ticket.ERequestType.Payment: l_payment.Add(t); break;
                        case Ticket.ERequestType.Subscription: l_subscription.Add(t); break;
                        case Ticket.ERequestType.Cancellation: l_cancellation.Add(t); break;
                    }
                }
                //
                for (global::System.Int32 i = 0; i < 3; i++)
                {
                    List<Ticket> tmp = new();
                    switch (i)
                    {
                        case 0: tmp = l_payment; break;
                        case 1: tmp = l_subscription; break;
                        case 2: tmp = l_cancellation; break;
                    }
                    Ticket[] t_array = BubbleSort(ListToArray(tmp));
                    foreach (Ticket ticket in t_array)
                    {
                        switch (i)
                        {
                            case 0: payments.Enqueue(ticket); break;
                            case 1: subscriptions.Enqueue(ticket); break;
                            case 2: cancellations.Enqueue(ticket); break;
                        }
                    }
                }

                result[0] = payments;
                result[1] = subscriptions;
                result[2] = cancellations;
            }

            return result;
        }
        internal static Ticket[] ListToArray(List<Ticket> tickets)
        {
            Ticket[] result = new Ticket[tickets.Count];
            for (int i = 0; i < tickets.Count; i++)
            {
                result[i] = tickets[i];
            }
            return result;
        }
        internal static Ticket[] BubbleSort(Ticket[] array)// Ticket edition
        {
            if (array.Length > 0 && array != null)
            {
                int n = array.Length;
                bool swapped;

                for (int i = 0; i < n - 1; i++)
                {
                    swapped = false;

                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (array[j].Turn > array[j + 1].Turn)
                        {
                            // Swap array[j] and array[j + 1]
                            Ticket temp = array[j];
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
            return array;
        }
        internal static bool AddNewTicket(Queue<Ticket> targetQueue, Ticket ticket)
        {
            if(targetQueue == null) return false;
            if (ticket.RequestType != targetQueue.Peek().RequestType) return false;

            if(ticket.Turn > 99)
            {
                /*
                int turn = (ticket.Turn % 99) + 1;
                Ticket t = new Ticket(ticket.RequestType, turn);
                targetQueue.Enqueue(t);
                */
                return false;
            }
            else
            {
                targetQueue.Enqueue(ticket);
                return true;
            }
        }        
    }
}