using System;
using System.Collections.Generic;
using System.Linq;

namespace genetic_algor
{
    class Population
        {
            private List<Individual> individ;
            private readonly int individCount;
            private readonly Random random;

            public static List<int> Key;

            public Population()
            {
                individ = new List<Individual>();
                random = new Random();

                individCount = 100;

                List<int> listparams = new List<int>();


                for (int i1 = 0; i1 < individCount; i1++)
                {
                    for (int i2 = 0; i2 < 6; i2++)
                    {
                        listparams.Add(random.Next(0, 101));
                    }

                    individ.Add(new Individual(listparams, random));

                    listparams.Clear(); // Очистить список параметров
                }
            }

            private void Selection()
            {
                individ = individ.OrderByDescending(o => o.GetAdeptness()).ToList();

                individ.RemoveRange
                    (
                        (int)Math.Round((double)individ.Count / 2),
                        (int)Math.Round((double)individ.Count / 2)
                    );

            }
            private void StartCrossing()
            {
                for (int i1 = 0; i1 < Math.Round((double)individCount); i1++)
                {
                    int momSelector;
                    int dadSelector;
                    do
                    {
                        dadSelector = random.Next(0, individCount);
                        momSelector = random.Next(0, individCount);
                    }
                    while (dadSelector == momSelector);
                    individ.Add(individ[dadSelector].Crossing(individ[momSelector]));
                }
            }
            private void StartMutation()
            {
                for (var i1 = 0; i1 < Math.Round((double)individCount / 10); i1++)
                {
                    var individSelector = random.Next(0, individCount * 2);

                    individ[individSelector].Mutation();
                }
            }
            public void MakeCycle()
            {
                StartCrossing();
                StartMutation();
                Selection();
            }
            public Individual GetBestIndividual()
            {
                return individ.First();


            }
        public int GetAvgWeight()
        {
            int iSumWeight = individ.Sum(indItem => indItem.GetAdeptness()); // Сумма весов п популяции

            return (int)Math.Round(iSumWeight / (double)individCount); // Вернуть значение среднего веса
        }
    }



        public class Individual
        {
            private int adept;
            private readonly List<int> param;
            private readonly Random indivrandom;

            private const int A = 2;
            private const int B = 3;
            private const int C = 4;

            public Individual(List<int> iParam, Random inputRandom)
            {
                param = new List<int>();


                foreach (var item in iParam)
                {
                    param.Add(item);
                }

                indivrandom = inputRandom;

                CalculateAdeptness();
            }
            public void Mutation()
            {
                for (int i1 = 0; i1 < indivrandom.Next(1, 4); i1++)
                {
                    
                    var mutationIndex = indivrandom.Next(0, 4);
                //
                // Изменяем значение выбранного параметра
                // 
                if (param[mutationIndex] == 0)
                {
                    param[mutationIndex] = 1; // Изменить на 1
                }
                else
                {
                    param[mutationIndex] = 0; // Изменить на 0
                }
            }
       
                CalculateAdeptness();
            }
            public Individual Crossing(Individual indSecondParent)
            {
                List<int> inputParams = new List<int>();
                inputParams.AddRange(param.GetRange(0, 2));
                inputParams.AddRange(indSecondParent.param.GetRange(2, 2));
                return new Individual(inputParams, indivrandom);
            }
            public int GetAdeptness()
            {
                return adept;
            }
            private void CalculateAdeptness()
            {
                adept = param[0] + A * param[1] + B * param[2] + C * param[3];
            }
            public List<int> GetParams()
            {
                return param;
            }
        }
    }


