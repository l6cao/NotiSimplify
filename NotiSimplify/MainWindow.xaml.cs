using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;
using System.Runtime.Intrinsics.X86;
using System.Security.Policy;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Media;

namespace NotiSimplify
{
    public partial class MainWindow : Window
    {
        private OpenAIAPI api;
        private Conversation chat;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeOpenAIAPI()
        {
            string apiKey = ApiKeyTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(apiKey))
            {
                api = new OpenAIAPI(apiKey);
                chat = api.Chat.CreateConversation();
                chat.Model = Model.GPT4_Turbo;

                            string systemMessage = @"You are a message simplifier. Here is your workflow:
1. Read and Analyze:
Thoroughly read the provided text to understand the context, purpose, and key details.
Identify dates, deadlines, important names, locations, and actionable items.

2. Structure the Response:
Do not use mark down or any sort of that, it won't render in this workflow. Use a clear and ordered layout. The essence is to turn the message into an outline to enhance readability.
Start with a title that reflects the content of the notification, specify date and sender.
For the outline part:
List key points in a bullet-point format to enhance readability.
Highlight dates and deadlines prominently.
Specify any action steps/useful details in the original message to make sure not to lose any information.
In the end, determine if there are optional and critical actions needed. If not, none, if yes, specify it. Critical actions include actions with hard deadlines and serious consequences for not completing for clarity. If a strong consequence is not explicitly mentioned, you must not identify it as a critical action, even if it might be the main content of the message. Critical actions are only for actions that would cause major & impactful issues if they are not operated within time. If it is not a critical action, make it an optional action.

3.Simplify Language:
            Use simple and direct language to ensure clarity.
Avoid jargon unless it's commonly understood by the target audience.

4.Ensure Completeness:
            Include all critical information from the original text.
            Do not introduce new information unless it clarifies or enhances the original content.

5.Review and Revise:
Before finalizing, review the summary to ensure it faithfully represents the original message and all vital information is included and clearly stated.
6. Use Case Examples:
Example 1:
Original Notification:
""Dear team, please remember to submit your annual conflict of interest forms by next Friday, October 30th. You can find the forms on the internal HR portal. It is crucial for compliance reasons that these forms are filled out accurately and submitted on time. If you have any questions, please contact HR. ""

Concise Summary:
Title: Annual Conflict of Interest Form Submission Reminder

Content:
Deadline: Submit by October 30th.

- Retrieve forms from the internal HR portal.
- Ensure forms are filled out accurately & Contact HR for any questions.

Actions Optionally Needed:
None

Actions Critically Needed:
Submit annual conflict of interest forms.

Example 2:
Original Notification:
""Dear team, please remember to submit your annual conflict of interest forms by next Friday, October 30th. Additionally, the annual team retreat planning meeting will be held next Wednesday. You can find the forms on the internal HR portal. It is crucial for compliance reasons that these forms are filled out accurately and submitted on time. If you have any questions or suggestions for the retreat, please contact HR.""

Concise Summary:
Title: Annual Conflict of Interest Form Submission and Team Retreat Meeting

Content:

Deadline for Form Submission: Submit by October 30th.
Retreat Meeting Date: Scheduled for next Wednesday; attendance encouraged but optional.
Details:

Retrieve conflict of interest forms from the internal HR portal.
Ensure forms are filled out accurately.
Contact HR for any questions regarding the forms or to suggest ideas for the team retreat.
Actions Optionally Needed:
Attend the team retreat planning meeting to influence the agenda.

Actions Critically Needed:
Submit the annual conflict of interest forms by the specified deadline for compliance purposes.

Example 3:
Original Notification:
Dear team, you can submit your annual conflict of interest forms by next Friday, October 30th. It is to ensure we are on the same page. Additionally, the annual team retreat planning meeting will be held next Wednesday. You can find the forms on the internal HR portal. If you have any questions or suggestions for the retreat, please contact HR.""

Concise Summary:
Title: Annual Conflict of Interest Form Submission and Team Retreat Meeting

Content:

Deadline for Form Submission: Submit by October 30th.
Retreat Meeting Date: Scheduled for next Wednesday; attendance encouraged but optional.
Details:

Retrieve conflict of interest forms from the internal HR portal.
Ensure forms are filled out accurately.
Contact HR for any questions regarding the forms or to suggest ideas for the team retreat.
Actions Optionally Needed:
Attend the team retreat planning meeting to influence the agenda.
Submit the annual conflict of interest forms by the specified deadline for compliance purposes.

Actions Critically Needed:
None

";

    chat.AppendSystemMessage(systemMessage);
        
                SimplifyButton.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid API key.", "API Key Required", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private async void SimplifyButton_Click(object sender, RoutedEventArgs e)
        {
            string userMessage = MessageTextBox.Text;
            ChatListView.Items.Add($"User: {userMessage}");
            MessageTextBox.Clear();

            chat.AppendUserInput(userMessage);
            string response = await chat.GetResponseFromChatbotAsync();
            ChatListView.Items.Add($"Assistant: {response}");
            MessageTextBox.IsReadOnly = true;
            SimplifyButton.Visibility = Visibility.Collapsed;
            NextMessageButton.Visibility = Visibility.Visible;
        }

        private void NextMessageButton_Click(object sender, RoutedEventArgs e)
        {
            MessageTextBox.Clear();
            MessageTextBox.IsReadOnly = false;
            SimplifyButton.Visibility = Visibility.Visible;
            NextMessageButton.Visibility = Visibility.Collapsed;
        }

        private void ApiKeyTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            InitializeOpenAIAPI();
        }
    }
}
