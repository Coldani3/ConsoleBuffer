using System.Linq;

namespace ConsoleBuffer
{
    class ConsoleBuffer
    {
        private char[] buffer;
        private List<int> dirtyIndexes = new List<int>();

        public ConsoleBuffer()
        {
            buffer = new char[Console.WindowWidth * Console.WindowHeight];
        }

        private void WriteAtIndex(int index, string toWrite) 
        {
            foreach (char character in toWrite) 
            {
                buffer[index] = character;
                dirtyIndexes.Add(index);
                index++;
            }
        }

        public void Write(int x, int y, string toWrite)
        {
            int index = this.ToIndex(x, y);

            WriteAtIndex(index, toWrite);
        }

        public void Write(string toWrite) {
            int index = dirtyIndexes.Last() + 1;
            WriteAtIndex(index, toWrite);
        }

        public void WriteLine(int startX, int startY, string contents) 
        {
            this.Write(startX, startY, contents + '\n');
        }

        public void Clear()
        {
            Array.Clear(buffer);
        }

        private int ToIndex(int x, int y) {
            return y * Console.WindowWidth + x;
        }

        public void OrderDirtyIndexes()
        {
            dirtyIndexes = dirtyIndexes.OrderBy(x => x).ToList();
        }

        public void Copy(ConsoleBuffer from) {
            this.buffer = from.buffer;
            dirtyIndexes.Clear();
        }
    }
}