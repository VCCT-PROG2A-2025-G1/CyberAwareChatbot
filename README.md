# ST10445158 PROG6221 POE Part 3
Screen recording of code running and explanation: https://youtu.be/Fw-UeS2wCbo 
Cyber Aware Chatbot
The Cyber Aware Chatbot is a WPF application designed to educate users about cybersecurity through an interactive chat interface, task management, and tutorials. Built with .NET, it offers a user-friendly experience with features like theme switching, activity logging, and sentiment detection, making it a fun and engaging tool for learning about phishing, password security, and more.
Features

Interactive Chatbot: Ask questions about cybersecurity topics (e.g., phishing, passwords) and receive informative responses. Use the "more" keyword to dive deeper into a topic.
Task Management: Create, complete, and delete tasks with reminders. The "Reminder" column shows the due date and time (hover for tooltip).
Tutorials: Learn through guided lessons on:
Password Security: Create a strong password with at least 12 characters, including uppercase, lowercase, numbers, and symbols.
Phishing Awareness: Identify suspicious emails and avoid unsafe links.


Theme Switching: Choose between light, dark, or blue themes for a personalized UI.
Activity Logging: Track user actions (e.g., sending messages, completing tasks) with a "Clear Logs" option to reset.
Points System: Earn points for interacting with the chatbot, completing tutorials, and quizzes.
Sentiment Detection: The chatbot responds to user emotions (e.g., "I’m worried" prompts supportive tips).
Help Menu: Access a quick guide for using the app.
Greeting Audio: Plays a welcome sound on startup (currently experiencing issues, see Known Issues).

Prerequisites

Windows OS: The app is built for Windows using WPF.
.NET Framework: Version 4.8 or later.
Visual Studio: 2019 or 2022 for development and building.
Newtonsoft.Json: For JSON serialization (installed via NuGet).
Greeting.wav: A valid .wav audio file for the greeting sound.

Installation

Clone the Repository:
git clone https://github.com/VCCT-PROG2A-2025-G1/CyberAwareChatbot.git
cd CyberAwareChatbot


Open in Visual Studio:

Open CyberAwareChatbot.sln in Visual Studio.
Ensure the target framework is .NET 4.8 or compatible.


Install Dependencies:

In Visual Studio, open the Package Manager Console and run:Install-Package Newtonsoft.Json




Configure Greeting.wav:

Place Greeting.wav in the Resources folder (CyberAwareChatbot\Resources\).
In Visual Studio, right-click Greeting.wav in Solution Explorer, select Properties, and set:
Build Action: Resource
Copy to Output Directory: Copy always


After building, verify Greeting.wav is in bin\Debug\Resources\.


Build the Project:

Press Ctrl+Shift+B or select Build > Build Solution.
Ensure bin\Debug\userData.json is writable for saving user data.



Usage

Run the Application:

Press F5 in Visual Studio or run bin\Debug\CyberAwareChatbot.exe.
The app starts with a greeting message (audio may not play due to a known issue).


Set Your Name:

Enter your name when prompted to personalize the experience.


Interact with the Chatbot:

Type cybersecurity questions (e.g., "What is phishing?") in the input box and click Send.
Use "more" to get additional details on a topic.
Earn 5 points per message.


Manage Tasks:

Click Add Task to create a task with a title, description, and reminder date.
Select a task and click Complete Task or Delete Task.
Hover over the "Reminder" column header to see its description: "The date and time when the task reminder is due."


Explore Tutorials:

Click Tutorial and choose:
Password Security: Follow steps to create a strong password (up to 15 points).
Phishing Awareness: Answer questions about suspicious emails (up to 15 points).


Points are awarded for correct answers and completion.


Switch Themes:

Select light, dark, or blue from the settings dropdown.


View and Clear Logs:

Click View Logs to see activity history.
Click Clear Logs to reset the log history.


Access Help:

Click Help for a quick guide on using the app.


Exit:

Type "exit" and confirm with "yes" to close the app, saving your data.



Known Issues

Greeting.wav Audio:
The app may display "Greeting audio file not found at [path]" on startup.
Ensure Greeting.wav is in bin\Debug\Resources\ and set to Copy always.
If the issue persists, check the activity log for detailed error messages (e.g., "Error playing greeting: [details]").
Workaround: Replace Greeting.wav with a known-working .wav file or disable audio in MainViewModel.cs.



Contributing
Contributions are welcome! To contribute:

Fork the repository.
Create a branch: git checkout -b feature/your-feature.
Commit changes: git commit -m "Add your feature".
Push to the branch: git push origin feature/your-feature.
Open a pull request with a clear description of changes.

## License
This project is open-source and available under the [MIT License](LICENSE).

## Author
Developed by Letlhogonolo Kgatshe (ST10445158, Group 1).
