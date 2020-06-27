using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOL
{
    class Organism
    {
        public int id;
        public Organism update(Organism[,] f, int width, int height, int x, int y)
        {
            int counter = 0;
            if (f[(width + x + 1) % width, y].id == 1) counter++;
            if (f[(width + x + 1) % width, (height + y + 1) % height].id == 1) counter++;
            if (f[x, (height + y + 1) % height].id == 1) counter++;
            if (f[(width + x - 1) % width, (height + y + 1) % height].id == 1) counter++;
            if (f[(width + x - 1) % width, y].id == 1) counter++;
            if (f[(width + x - 1) % width, (height + y - 1) % height].id == 1) counter++;
            if (f[x, (height + y - 1) % height].id == 1) counter++;
            if (f[(width + x + 1) % width, (height + y - 1) % height].id == 1) counter++;
            Organism r = new Organism();
            if (id == 1)
            {
                if (counter == 3 || counter == 2)
                    r.id = 1;
            }
            else
                if (counter == 3)
                r.id = 1;
            return r;
        }
    }
}

