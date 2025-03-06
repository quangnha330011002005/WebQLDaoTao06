<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuizGame.aspx.cs" Inherits="WebQLDaoTao.QuizGame" %>

<!DOCTYPE html>
<html lang="vi">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Đoán Số - Web Forms</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            text-align: center;
            margin-top: 50px;
            background-image: url('https://th.bing.com/th/id/R.cc1b17fa0a80057452f212110c098b12?rik=aN0rVrLUj3hQXQ&riu=http%3a%2f%2fwallpapercave.com%2fwp%2fefwXdPf.jpg&ehk=0CWWGi%2bMmNA31kMRfiDoFx8KsORc0Um6n23J4imT7F8%3d&risl=&pid=ImgRaw&r=0');
            background-size: cover;
            color: white;
        }
        input, button {
            margin-top: 10px;
            padding: 5px;
        }
        .hidden {
            display: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Trò Chơi Đoán Số</h1>

        <asp:Button ID="btnBack" runat="server" Text=" 🏠 Trở Về Trang Chính" OnClick="btnBack_Click1" CssClass="btn btn-success" />

        <div id="game-section">
            <p>Đoán một số từ 1 đến 100!</p>
            <asp:TextBox ID="txtGuess" runat="server" type="number" min="1" max="100"></asp:TextBox>
            <asp:Button ID="btnGuess" runat="server" Text="Đoán" OnClick="btnGuess_Click" />
            <asp:Button ID="btnRestart" runat="server" Text="Bắt Đầu Lại" OnClick="btnRestart_Click" />

            <div id="message">
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </div>
            <div id="attempts">
                Số lần đoán còn lại: <asp:Label ID="lblAttempts" runat="server" Text="10"></asp:Label>
            </div>
            <div id="history">
                Lịch sử đoán: <asp:Label ID="lblHistory" runat="server" Text=""></asp:Label>
            </div>
            <div id="xp">
                Điểm XP: <asp:Label ID="lblXP" runat="server" Text="0"></asp:Label>
            </div>
        </div>

        <div class="leaderboard">
            <h2>🏆 Bảng Xếp Hạng</h2>
            <asp:Label ID="lblLeaderboard" runat="server" Text="Chưa có ai chơi"></asp:Label>
        </div>
        
    </form>
</body>
</html>
