#include "gtest/gtest.h"
#include "Board.h"

namespace CommonTests
{
   class TestBoard : public ::testing::Test
   {
   public:

      TestBoard()
      {
      }

      ~TestBoard()
      {
      }
   };

   TEST_F(TestBoard, Complete_square)
   {
      char boardArray[8][8] = 
      {
         { '.', '.', '.', '.', '.', '.', '.', '.' },
         { '.', '.', '.', '.', '.', '.', '.', '.' },
         { '.', '.', '.', '.', '.', '.', '.', '.' },
         { '.', '.', '.', '*', '*', '.', '.', '.' },
         { '.', '.', '.', '*', '.', '.', '.', '.' },
         { '.', '.', '.', '.', '.', '.', '.', '.' },
         { '.', '.', '.', '.', '.', '.', '.', '.' },
         { '.', '.', '.', '.', '.', '.', '.', '.' }
      };
      Board board(8, 8, &boardArray[0][0]);

      board.Run();

      char* newBoard = board.get_Board();
      char op = newBoard[16];
      ASSERT_EQ('*', op);
   }
}
