using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixT
{
    class Competitors
    {
        public Competitor[] CompetitorsList;

        public Competitor[] Aside { get; set; }

        public Competitor[] Bside { get; set; }

        public Competitor[] Qualifers { get; set; }

        public bool Split;

        public void SetSplit(bool s)
        {
            Split = s;
        }

        public void AddCompetitors(string[,] data)
        {
            int range = data.Length / 2;
            CompetitorsList = new Competitor[range];

            for (int i = 0; i < range; i++)
            {
                CompetitorsList[i] = new Competitor(data[i, 0], data[i, 1]);
            }
        }

        public void PrintCompetitors()
        {
            for (int i = 0; i < CompetitorsList.Length; i++)
            {
                Console.WriteLine(CompetitorsList[i].name + CompetitorsList[i].team);
            }
        }

        public void PrintAside()
        {
            for (int i = 0; i < Aside.Length; i++)
            {
                if (Aside[i].name != null)
                    Console.WriteLine(Aside[i].name + Aside[i].team);
            }
        }

        public void PrintBside()
        {
            for (int i = 0; i < Bside.Length; i++)
            {
                if (Bside[i].name != null )
                    Console.WriteLine(Bside[i].name + Bside[i].team);
            }
        }

        public void Shuffle()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int value = 0;

            for (int i = 0; i < CompetitorsList.Length; i++)
            {
                value = rand.Next(0, CompetitorsList.Length);

                Competitor cAux = CompetitorsList[value];
                CompetitorsList[value] = CompetitorsList[i];
                CompetitorsList[i] = cAux;
            }
        }

        public void ShuffleSides()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int value = 0;

            for (int i = 0; i < Aside.Length; i++)
            {
                value = rand.Next(0, Aside.Length);

                Competitor cAux = Aside[value];
                Aside[value] = Aside[i];
                Aside[i] = cAux;
            }

            for (int i = 0; i < Bside.Length; i++)
            {
                value = rand.Next(0, Bside.Length);

                Competitor cAux = Bside[value];
                Bside[value] = Bside[i];
                Bside[i] = cAux;
            }
        }

        public bool HasATeammate(Competitor c)
        {
            for(int i=0; i<CompetitorsList.Length; i++)
            {
                if (CompetitorsList[i].team != null && CompetitorsList[i].team == c.team && CompetitorsList[i].name != c.name)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsAside(Competitor c)
        {
            for (int i = 0; i < (Qualifers.Length/2); i++)
            {
                if (Qualifers[i].team != null && Qualifers[i].team == c.team && Qualifers[i].name != c.name)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsBside(Competitor c)
        {
            for (int i = (Qualifers.Length/2); i < Qualifers.Length; i++)
            {
                if (Qualifers[i].team != null && Qualifers[i].team == c.team && Qualifers[i].name != c.name)
                {
                    return true;
                }
            }
            return false;
        }

        public void GenerateQualifers()
        {
            if (CompetitorsList.Length <= 2) Qualifers = new Competitor[2];
            else if (CompetitorsList.Length <= 4) Qualifers = new Competitor[4];
            else if (CompetitorsList.Length <= 8) Qualifers = new Competitor[8];
            else if (CompetitorsList.Length <= 16) Qualifers = new Competitor[16];
            else if (CompetitorsList.Length <= 32) Qualifers = new Competitor[32];
            else if (CompetitorsList.Length <= 64) Qualifers = new Competitor[64];

            int[] st02 = { 0, 1 };
            int[] st04 = { 0, 2, 1, 3 };
            int[] st08 = { 0, 4, 3, 7, 1, 5, 2, 6 };
            int[] st16 = { 0, 8, 7,15, 1,9, 6,14, 2,10, 5,13, 3,11, 4,12 };
            int[] st32 = { 0, 16, 15, 31, 1,17, 14,30, 2,18, 13,29, 3,19, 12,28, 4,20, 11,27, 5,21, 10,26, 6,22, 9,25, 7,23, 8,24 };

            int[] array = { };

            if (CompetitorsList.Length <= 2) array = st02;
            else if (CompetitorsList.Length <= 4) array = st04;
            else if (CompetitorsList.Length <= 8) array = st08;
            else if (CompetitorsList.Length <= 16) array = st16;
            else { array = st32; }
 
            //first repeaters
            for (int i = 0; i < CompetitorsList.Length; i++)
            {
                if (HasATeammate(CompetitorsList[i]))
                {
                    for (int j = 0; j < array.Length; j++)
                    {
                        if (Qualifers[array[j]].name == null)
                        {
                            Qualifers[array[j]] = CompetitorsList[i];
                            break;
                        }
                    }
                }
            }

            //else
            for (int i = 0; i < CompetitorsList.Length; i++)
            {
                if (!HasATeammate(CompetitorsList[i]))
                {
                    for (int j = 0; j < array.Length; j++)
                    {
                        if (Qualifers[array[j]].name == null)
                        {
                            Qualifers[array[j]] = CompetitorsList[i];
                            break;
                        }
                    }
                }
            }

            Aside = Qualifers.Take(Qualifers.Length/2).ToArray();
            Bside = Qualifers.Skip(Qualifers.Length/2).ToArray();

        }

        public void GenerateSides()
        {

            if(CompetitorsList.Length <= 2)
            {
                Aside = new Competitor[1];
                Bside = new Competitor[1];
            }
            else if (CompetitorsList.Length <= 4)
            {
                Aside = new Competitor[2];
                Bside = new Competitor[2];
            }
            else if (CompetitorsList.Length <= 8)
            {
                Aside = new Competitor[4];
                Bside = new Competitor[4];
            }
            else if (CompetitorsList.Length <= 16)
            {
                Aside = new Competitor[8];
                Bside = new Competitor[8];
            }
            else if (CompetitorsList.Length <= 32)
            {
                Aside = new Competitor[16];
                Bside = new Competitor[16];

            }
            else if (CompetitorsList.Length <= 64)
            {
                Aside = new Competitor[32];
                Bside = new Competitor[32];
            }
            else if (CompetitorsList.Length <= 128)
            {
                Aside = new Competitor[64];
                Bside = new Competitor[64];
            }


            /*if (CompetitorsList.Length % 2 == 0)
            {
                range = CompetitorsList.Length / 2;
                Aside = new Competitor[range];
                Bside = new Competitor[range];
            }
            else
            {
                range = CompetitorsList.Length / 2;
                Aside = new Competitor[range + 1];
                Bside = new Competitor[range];
            }*/

            //Console.WriteLine("Range side: " + range);

            //Caso 3 o mas
            
            
            
            for (int i = 0; i < CompetitorsList.Length; i++)
            {
                if (i == 0)
                {
                    Aside[0] = CompetitorsList[0];
                }
                else
                {
                    if (NotRepeaterBothSides(CompetitorsList[i]))
                    {
                        if (countSide(Aside) < countSide(Bside)){
                            int p = PosiblePosition(Aside);
                            Aside[p] = CompetitorsList[i];
                        }
                        else if (countSide(Aside) > countSide(Bside)){
                            int p = PosiblePosition(Bside);
                            Bside[p] = CompetitorsList[i];
                        }
                        else
                        {
                            int value = CoinLuck();
                            if(value == 0)
                            {
                                int p = PosiblePosition(Aside);
                                Aside[p] = CompetitorsList[i];
                            }
                            else
                            {
                                int p = PosiblePosition(Bside);
                                Bside[p] = CompetitorsList[i];
                            }
                        }
                    }
                    else
                    { 
                        if(TeamCount(CompetitorsList[i], Aside) < TeamCount(CompetitorsList[i], Bside))
                        {
                            if (NotFull(Aside))
                            {
                                int p = PosiblePosition(Aside);
                                Aside[p] = CompetitorsList[i];
                            }
                            else
                            {
                                int p = PosiblePosition(Bside);
                                Bside[p] = CompetitorsList[i];
                            }
                        }
                        else if (TeamCount(CompetitorsList[i], Aside) > TeamCount(CompetitorsList[i], Bside))
                        {
                            if (NotFull(Bside))
                            {
                                int p = PosiblePosition(Bside);
                                Bside[p] = CompetitorsList[i];
                            }
                            else
                            {
                                int p = PosiblePosition(Aside);
                                Aside[p] = CompetitorsList[i];
                            }
                        }
                        else
                        {
                            int value = CoinLuck();
                            if (value == 0)
                            {
                                int p = PosiblePosition(Aside);
                                Aside[p] = CompetitorsList[i];
                            }
                            else
                            {
                                int p = PosiblePosition(Bside);
                                Bside[p] = CompetitorsList[i];
                            }
                        }
                    }

                }

                /*if (i == 0)
                {
                    Aside[0] = CompetitorsList[0];
                }
                else
                {
                    if (Split == true)
                    {
                        if (NotRepeaterBothSides(CompetitorsList[i]))
                        {
                            int luck = SelectedSide(CompetitorsList[i]);
                            
                            if (luck == 0 && NotFull(Aside) && NotRepeater(CompetitorsList[i], Aside))
                            {
                                int p = PosiblePosition(Aside);
                                Aside[p] = CompetitorsList[i];
                            }
                            else
                            {
                                int p = PosiblePosition(Bside);
                                Bside[p] = CompetitorsList[i];
                            }
                        }
                        else
                        {
                            int luck = CoinLuck();

                            if(TeamCount(CompetitorsList[i], Aside) == TeamCount(CompetitorsList[i], Aside))
                            {
                                Console.WriteLine(TeamCount(CompetitorsList[i], Aside));

                                if (NotFull(Aside))
                                {
                                    int p = PosiblePosition(Aside);
                                    Aside[p] = CompetitorsList[i];
                                }
                                else
                                {
                                    int p = PosiblePosition(Bside);
                                    Bside[p] = CompetitorsList[i];
                                }
                            }
                            else
                            {
                                if (TeamCount(CompetitorsList[i], Aside) > TeamCount(CompetitorsList[i], Aside))
                                {
                                    if (NotFull(Bside)){
                                        int p = PosiblePosition(Bside);
                                        Bside[p] = CompetitorsList[i];
                                    }
                                    else
                                    {
                                        int p = PosiblePosition(Aside);
                                        Aside[p] = CompetitorsList[i];
                                    }
                                }
                                else
                                {
                                    if (NotFull(Aside))
                                    {
                                        int p = PosiblePosition(Aside);
                                        Aside[p] = CompetitorsList[i];
                                    }
                                    else
                                    {
                                        int p = PosiblePosition(Bside);
                                        Bside[p] = CompetitorsList[i];
                                    }
                                }
                            }
                           
                        }
                    }
                    else
                    {
                        if (NotFull(Aside))
                        {
                            int p = PosiblePosition(Aside);
                            Aside[p] = CompetitorsList[i];
                        }
                        else
                        {
                            int p = PosiblePosition(Bside);
                            Bside[p] = CompetitorsList[i];
                        }
                    }
                        
                }*/
            }
        }

        public bool NotRepeaterBothSides(Competitor c)
        {
            if (NotRepeater(c, Aside) && NotRepeater(c, Bside))
                return true;
            else
                return false;
        }

        public int CoinLuck()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            return (rand.Next(0, 2));
            
        }

        public int TeamCount(Competitor c, Competitor[] side)
        {
            int count = 0;
            for (int i = 0; i < side.Length; i++)
            {
                if (side[i].team != null && side[i].team == c.team)
                {
                    count++;
                }
            }
            return count;
        }

        public bool NotRepeater(Competitor c,Competitor[] side)
        {
            for (int i = 0; i < side.Length; i++)
            {
                if (side[i].team != null && side[i].team == c.team)
                {
                    return false;
                }
            }
            return true;
        }

        public bool NotFull(Competitor[] side)
        {
            for (int i = 0; i < side.Length; i++)
            {
                if (side[i].name == null)
                {
                    return true;
                }
            }
            
            return false;
        }

        /*public int PosiblePosition(Competitor[] side)
        {
            int position = 0;
            for (int i = 0; i < side.Length; i++)
            {
                if (side[i].name == null)
                {
                    return i;
                }
            }
            return position;
        }*/

        public int PosiblePosition(Competitor[] side)
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int position = 0;

            int[] st04 = { 0, 4, 2, 6 };
            int[] st08 = { 0, 6, 8, 14 };
            int[] st16 = { 0,14,16, 32 };
            int[] st32 = { 0,30,32, 62 };

            while (true)
            {
                position = rand.Next(0, side.Length);
            
                if (side[position].name == null)
                {
                    return position;
                }
            }
        }

        public int countSide(Competitor[] side)
        {
            int count = 0;
            for(int i=0; i < side.Length; i++)
            {
                if (side[i].name != null)
                {
                    count++;
                }
            }
            return count;
        }

    }
}
