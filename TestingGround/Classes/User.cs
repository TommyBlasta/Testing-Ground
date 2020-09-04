using System;
namespace TestingGround.Classes
{
    //Write a class called User that is used to calculate the amount that a user will progress through a ranking system similar to the one Codewars uses.

    //Business Rules:
    //A user starts at rank -8 and can progress all the way to 8.
    //There is no 0 (zero) rank. The next rank after -1 is 1.
    //Users will complete activities. These activities also have ranks.
    //Each time the user completes a ranked activity the users rank progress is updated based off of the activity's rank
    //The progress earned from the completed activity is relative to what the user's current rank is compared to the rank of the activity
    //A user's rank progress starts off at zero, each time the progress reaches 100 the user's rank is upgraded to the next level
    //Any remaining progress earned while in the previous rank will be applied towards the next rank's progress (we don't throw any progress away). The exception is if there is no other rank left to progress towards(Once you reach rank 8 there is no more progression).
    //A user cannot progress beyond rank 8.
    //The only acceptable range of rank values is -8,-7,-6,-5,-4,-3,-2,-1,1,2,3,4,5,6,7,8. Any other value should raise an error.
    //The progress is scored like so:

    //Completing an activity that is ranked the same as that of the user's will be worth 3 points
    //Completing an activity that is ranked one ranking lower than the user's will be worth 1 point
    //Any activities completed that are ranking 2 levels or more lower than the user's ranking will be ignored
    //Completing an activity ranked higher than the current user's rank will accelerate the rank progression. The greater the difference between rankings the more the progression will be increased. The formula is 10 * d * d where d equals the difference in ranking between the activity and the user.
    //Logic Examples:
    //If a user ranked -8 completes an activity ranked -7 they will receive 10 progress
    //If a user ranked -8 completes an activity ranked -6 they will receive 40 progress
    //If a user ranked -8 completes an activity ranked -5 they will receive 90 progress
    //If a user ranked -8 completes an activity ranked -4 they will receive 160 progress, resulting in the user being upgraded to rank -7 and having earned 60 progress towards their next rank
    //If a user ranked -1 completes an activity ranked 1 they will receive 10 progress(remember, zero rank is ignored)

    //User user = new User();
    //user.rank; // => -8
    //user.progress; // => 0
    //user.incProgress(-7);
    //user.progress; // => 10
    //user.incProgress(-5); // will add 90 progress
    //user.progress; // => 0 // progress is now zero
    //user.rank; // => -7 // rank was upgraded to -7
    public class User
    {
        private int progress;

        public int Rank { get; private set; }
        public int Progress
        {
            get => progress;
            private set
            {
                if(this.Rank == 8)
                {
                    progress = 0;
                    return;
                }
                else
                {
                    progress = value;
                    while (progress >= 100)
                    {
                        if (IncRank())
                        {
                            progress -= 100;
                        }
                        else
                        {
                            break;
                        }

                    }
                    if(this.Rank == 8)
                    {
                        progress = 0;
                    }
                }
                
            }
        }
        public User()
        {
            this.Rank = -8;
            this.Progress = 0;
        }
        public void IncProgress(int testRank)
        {
            try
            {
                if (this.Rank == 8)
                {
                    return;
                }
                else
                {
                    Progress += Diff(this.Rank, testRank);
                }
            }
            catch
            {
                throw;
            }

        }

        private bool IncRank()
        {
            if (this.Rank == -1)
            {
                this.Rank = 1;
                return true;
            }
            else if (this.Rank == 8)
            {

                return false;
            }
            else
            {
                this.Rank++;
                return true;
            }

        }
        private int RankToRealOrder(int rank)
        {
            if (rank < 0)
            {
                return (rank + 8) + 1;
            }
            else
            {
                return rank + 8;
            }
        }
        private int Diff(int userRank, int testRank)
        {
            if (userRank < -8 || userRank > 8 || testRank < -8 || testRank > 8 || userRank == 0 || testRank == 0)
            {
                throw new ArgumentException("Invalid ranks given");
            }
            else
            {
                int realDiff = RankToRealOrder(testRank) - RankToRealOrder(userRank);
                //test lower by 2 than the user
                if (realDiff <= -2)
                {
                    return 0;
                }
                //test lower by one than the user
                else if (realDiff == -1)
                {
                    return 1;
                }
                //test the same level as user
                else if (realDiff == 0)
                {
                    return 3;
                }
                //else use the formula for difference
                else
                {
                    return 10 * realDiff * realDiff;
                }

            }
        }


    }

}
