using System;
using System.Collections.Generic;
using System.Linq;

namespace genetic_algor
{
    class population
        {
            private List<Individual> _individ;
            private  int _individCount;
            private  Random _random;

            public static List<int> key;

            public population()
            {
                _individ = new List<Individual>();
                _random = new Random();

                _individCount = 100;

                List<int> listparams = new List<int>();


                for (int i1 = 0; i1 < _individCount; i1++)
                {
                    for (int i2 = 0; i2 < 6; i2++)
                    {
                        listparams.Add(_random.Next(0, 101));
                    }

                    _individ.Add(new Individual(listparams, _random));

                    listparams.Clear(); // Очистить список параметров
                }
            }

            private void Selection()
            {
                _individ = _individ.OrderByDescending(o => o.get_adeptness()).ToList();

                _individ.RemoveRange
                    (
                        (int)Math.Round((double)_individ.Count / 2),
                        (int)Math.Round((double)_individ.Count / 2)
                    );

            }
            private void start_crossing()
            {
                for (int i1 = 0; i1 < Math.Round((double)_individCount); i1++)
                {
                    int momSelector;
                    int dadSelector;
                    do
                    {
                        dadSelector = _random.Next(0, _individCount);
                        momSelector = _random.Next(0, _individCount);
                    }
                    while (dadSelector == momSelector);
                    _individ.Add(_individ[dadSelector].Crossing(_individ[momSelector]));
                }
            }
            private void start_mutation()
            {
                for (var i1 = 0; i1 < Math.Round((double)_individCount / 10); i1++)
                {
                    var individSelector = _random.Next(0, _individCount * 2);

                    _individ[individSelector].Mutation();
                }
            }
            public void make_cycle()
            {
                start_crossing();
                start_mutation();
                Selection();
            }
            public Individual get_best_individual()
            {
                return _individ.First();


            }
        public int get_avg_weight()
        {
            int i__sum_weight = 0; // Сумма весов п популяции

            foreach (Individual ind__item in _individ)
            {
                i__sum_weight += ind__item.get_adeptness(); // Прибавить вес
            }

            return (int)Math.Round(i__sum_weight / (double)_individCount); // Вернуть значение среднего веса
        }
    }



        public class Individual
        {
            private int _adept;
            private  List<int> _param;
            private  Random _indivrandom;
            int _a = 2;
            int _b = 3;
            int _c = 4;


            public Individual(List<int> iParam, Random inputRandom)
            {
                _param = new List<int>();


                foreach (var item in iParam)
                {
                    _param.Add(item);
                }

                _indivrandom = inputRandom;

                calculate_adeptness();
            }
            public void Mutation()
            {
                for (int i1 = 0; i1 < _indivrandom.Next(1, 4); i1++)
                {
                    var mutationIndex = _indivrandom.Next(0, 4);


                }

                calculate_adeptness();
            }
            public Individual Crossing(Individual indSecondParent)
            {
                List<int> inputParams = new List<int>();
                inputParams.AddRange(_param.GetRange(0, 2));
                inputParams.AddRange(indSecondParent._param.GetRange(2, 2));
                return new Individual(inputParams, _indivrandom);
            }
            public int get_adeptness()
            {
                return _adept;
            }
            private void calculate_adeptness()
            {
                _adept = _param[0] + _a * _param[1] + _b * _param[2] + _c * _param[3];
            }
            public List<int> GetParams()
            {
                return _param;
            }
        }
    }


