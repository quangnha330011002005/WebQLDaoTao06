using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;


namespace WebQLDaoTao
{
    public partial class QuizGame : System.Web.UI.Page
    {
        private static readonly Random random = new Random();
        private void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ResetGame();
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnGuess_Click(object sender, EventArgs e)
        {
            if (Session["RandomNumber"] == null)
            {
                ResetGame();
            }

            int randomNumber = (int)Session["RandomNumber"];
            int attempts = (int)Session["Attempts"];
            int xp = (int)Session["XP"];
            List<int> guessHistory = (List<int>)Session["GuessHistory"];

            if (int.TryParse(txtGuess.Text, out int userGuess))
            {
                if (userGuess < 1 || userGuess > 100)
                {
                    lblMessage.Text = "❌ Vui lòng nhập số từ 1 đến 100!";
                    return;
                }

                guessHistory.Add(userGuess);
                Session["GuessHistory"] = guessHistory;
                attempts--;
                Session["Attempts"] = attempts;

                if (userGuess < randomNumber)
                {
                    lblMessage.Text = "📈 Cao hơn!";
                }
                else if (userGuess > randomNumber)
                {
                    lblMessage.Text = "📉 Thấp hơn!";
                }
                else
                {
                    lblMessage.Text = $"🎉 Chúc mừng! Bạn đoán đúng số {randomNumber}.";
                    SaveToLeaderboard(attempts);
                    Session["RandomNumber"] = null; // Kết thúc game
                }

                // Cập nhật XP
                xp += 5; // Mỗi lần đoán +5 XP
                Session["XP"] = xp;

                lblAttempts.Text = attempts.ToString();
                lblHistory.Text = string.Join(", ", guessHistory);
                lblXP.Text = xp.ToString();

                if (attempts <= 0)
                {
                    lblMessage.Text = $"❌ Bạn đã hết lượt đoán! Số đúng là {randomNumber}.";
                    Session["RandomNumber"] = null; // Kết thúc game
                }
            }
            else
            {
                lblMessage.Text = "⚠️ Vui lòng nhập một số hợp lệ.";
            }
        }

        private void SaveToLeaderboard(int attempts)
        {
            List<(string Name, int Attempts)> leaderboard = (List<(string, int)>)Application["Leaderboard"] ?? new List<(string, int)>();

            string playerName = "Người chơi " + new Random().Next(1000, 9999);
            int totalAttempts = 10 - attempts;

            leaderboard.Add((playerName, totalAttempts));

            // Sắp xếp theo số lần đoán ít nhất
            leaderboard = leaderboard.OrderBy(x => x.Attempts).Take(5).ToList();
            Application["Leaderboard"] = leaderboard;

            LoadLeaderboard();
        }

        private void LoadLeaderboard()
        {
            List<(string Name, int Attempts)> leaderboard = (List<(string, int)>)Application["Leaderboard"] ?? new List<(string, int)>();

            if (leaderboard.Count == 0)
            {
                lblLeaderboard.Text = "Chưa có ai chơi.";
            }
            else
            {
                lblLeaderboard.Text = string.Join("<br>", leaderboard.Select(x => $"🏅 {x.Name}: {x.Attempts} lần"));
            }
        }

        private void ResetGame()
        {
            int randomNumber = random.Next(1, 101);
            Session["RandomNumber"] = randomNumber;
            Session["Attempts"] = 10;
            Session["XP"] = 0;
            Session["GuessHistory"] = new List<int>();

            lblMessage.Text = "0";
            lblAttempts.Text = "10";
            lblHistory.Text = "";
            lblXP.Text = "0";
        }

    
        

        protected void btnRestart_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        protected void btnBack_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}