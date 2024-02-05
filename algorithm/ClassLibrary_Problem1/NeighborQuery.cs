namespace ClassLibraryProb1;

 public class NeighborQuery
 {
        
        private static readonly object lockRoot = new object();
        private static int[][] prefixMatrix;

        private static int[][] directions = { 
            [-1, 0], // immediate left  
            [-1, -1], // leftmost diagonal
            [0, -1],  // immediate top
            [1, -1],  // upper right diagonal
            [1, 0],  // immediate right
            [1, 1],  // lower right diagonal
            [0, 1],  // immediate bottom
            [-1, 1]  // lower left diagonal
        };

        public static int getNeiboringHouseCount(int[][] mat, int houseNumber)
        {
            lock (lockRoot)
            {
                if (prefixMatrix == null || prefixMatrix.Length <= 0)
                {
                    prefixMatrix = BuildPrefixMatrix(mat, false);    
                }
            }
            
            
            int m = mat.Length, n = mat[0].Length;
            
            houseNumber--; // because matrix is zero-based, so adjusted by decrement by 1
            if (houseNumber < 0 || houseNumber >= m * n)
            {
                throw new ArgumentException(
                    $"Error: passed in value for parameter houseNumber, {houseNumber} is out of range [0, {m * n - 1}");
            }
            
            int row = houseNumber / n, col = houseNumber % n; 
            return prefixMatrix[row][col];
            
        }

        private static int[][] BuildPrefixMatrix(int[][] mat, bool forRow)
        {
            int m = mat.Length, n = mat[0].Length;
            prefixMatrix = new int [m][];
            for (int r = 0; r < m; ++r)
            {
                prefixMatrix[r] = new int[n];
            }

            for (int r = 0; r < m; ++r)
            {
                for (int c = 0; c < n; ++c)
                {
                    int sm = 0;
                    foreach (var dir in directions)
                    {
                        int newx = r + dir[0], newy = c + dir[1];
                        if(!isValid(newx, newy, m, n)) continue;
                        sm += mat[newx][newy];
                    }
                    prefixMatrix[r][c] = sm;
                }
            }
            return prefixMatrix;
        }

        private static bool isValid(int newx, int newy, int rowCount, int colCount)
        {
            if (newx >= 0 && newx < rowCount && newy >= 0 && newy < colCount)
            {
                return true;
            }

            return false;
        }
    }