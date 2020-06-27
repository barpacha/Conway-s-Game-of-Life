using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace GOL
{
    class Field
    {
        public int height, width, population, log_size = 0, iter = 0;
        public Organism[,] field;
        List<Organism[,]> log;
        public void init(int x, int y, int population)
        {
            width = x;
            height = y;
            log = new List<Organism[,]>();
            this.population = population;
            field = new Organism[width, height];
            Random rnd = new Random();
            
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                {
                    field[i, j] = new Organism();
                    if (population < rnd.Next(101))
                        field[i, j].id = 1;
                    else
                        field[i, j].id = 0;
                }
        }
        public Organism[,] frame()
        {
            Organism[,] next = new Organism[width, height];
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    next[j, i] = field[j, i].update(field, width, height, j, i);
            field = next;
            if (checkLog())
            {
                init(width, height, population);
                removeLog();
                Thread.Sleep(2000);
                iter = 0;
            }
            writeLog();
            iter++;
            return field;
        }
        private void writeLog()
        {
            if (log_size >= 10)
            {
                log.RemoveAt(0);
                log_size--;
            } 
            log.Add(field);
            log_size++;
        }
        private bool checkLog()
        {
            foreach(Organism[,] org in log)
            {
                for (int i = 0; i < height; i++)
                    for (int j = 0; j < width; j++)
                    {
                        if (org[j, i].id != field[j, i].id)
                        {
                            goto dif;
                        }
                    }
                return true;
                dif:;
            }
            return false;
        }
        private void removeLog()
        {
            log = new List<Organism[,]>();
            log_size = 0;
        }
    }
}
