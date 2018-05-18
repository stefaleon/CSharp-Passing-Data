## [Passing Data Between Forms](https://www.c-sharpcorner.com/article/passing-data-between-forms/)

### by [Thiagarajan Alagarsamy](https://www.c-sharpcorner.com/members/thiagarajan-alagarsamy)


A Windows Forms solution demonstrating usage of constructors, objects, properties and delegates.


### The PassDataBetweenForms solution

- The solution contains four projects

  - PassDataBetweenForms - Pass data using a **constructor** for Form2
  - PassDataBetweenForms2 - Pass data by passing each form as an **object** to the other
  - PassDataBetweenForms3 - Pass data using **properties**, a **get** property for the textBox1.Text in Form1 and a **set** property for the label1.Text in Form2.
  - PassDataBetweenForms4 - Pass data using a **delegate**


------------------------------------------------------------------
_The original text written by **Thiagarajan Alagarsamy** from (https://www.c-sharpcorner.com/article/passing-data-between-forms/) is added below, with minor code adjustments for .NET 4.6.1 in some parts of the code_


### Introduction

Some of you would have faced a scenario where you wanted to pass data from one form to another in WinForms. Honestly, I too had a similar problem (that's why I am writing this article!).



There are so many methods (How many? I don't know) to pass data between forms in windows application. In this article let me take four important (easiest) ways of accomplishing this.

- Using constructor

- Using objects

- Using properties

- Using delegates




Let us see all the above methods in detail in the following sections.

For a data to be passed between forms using any of the above methods, we need two forms and some controls. Let us start by following the below steps.

- Step 1: Create new project and select windows application. This will create a default form as "Form1". We can use this form for sending data.

- Step 2: Add a textbox and a button to the form.

- Step 3: Add another windows form for receiving the data and to display it. Right click the project and select Add -> Add Windows Form. Enter a name or use the default name "Form2.cs" and click ok button.

- Step 4: Add a label to the second form to display the text from form1



### The Constructor Approach

This could be the easiest method of all. A method is invoked whenever you instantiate an object. This method is called a constructor. Code a constructor for form2 class with one string parameter. In the constructor assign the text to the label's text property. Instantiate form2 class in form1's button click event handler using the constructor with one string parameter and pass the textbox's text to the constructor.

Follow the below steps.

Step 1: Code a constructor for form2 class as below

     public Form2(string strTextBox)

     {

          InitializeComponent();

          label1.Text=strTextBox;

     }

Step 2: Instantiate form2 class in form1's button click event handler as below

     private void button1_Click(object sender, System.EventArgs e)

     {

          Form2 frm=new Form2(textBox1.Text);

          frm.Show();

     }  

### The Object Approach

Objects are reference types, and are created on the heap, using the keyword `new`. Here we are going to pass data using objects. The approach is simple; in form2 we are going to instantiate form1 class.

Then instantiate form2 in the button click event handler of form1. After this we are going to pass form1 object to the form2 using form2's form1 object. The last step is to invoke the form2 window by calling the form2's show method.

Follow the below steps:



Step 1: Change the access modifier for textbox in form1 to public

     public class Form1 : System.Windows.Forms.Form

     {

          public System.Windows.Forms.TextBox textBox1;         



Step 2:  In form2.cs, instantiate form1 class

       public class Form2 : System.Windows.Forms.Form

       {

            private System.Windows.Forms.Label label1;

            public Form1 frm1;   


Step 3: In form1, in the button click event-handler add the following code.

     private void btnSend_Click(object sender, System.EventArgs e)

     {

         Form2 frm= new Form2();

         frm.frm1=this;

         frm.Show();

     }



Step 4: In Form2's Load method type cast the object (frm1) of form1 to Form1 and access form1's textbox and assign its text to label's text.

     private void Form2_Load(object sender, System.EventArgs e)

     {

          label1.Text=((Form1)frm1).textBox1.Text;

     }


### The Properties Approach


Properties allow clients to access class state as if they were accessing member fields directly, while actually implementing that access through a class method. In this method we are going to add one property to each form. In form1 we are going to use one property for retrieving value from the textbox and in form2, one property to set the label's text property. Then, in form1's button click event handler we are going to instantiate form2 and use the form2's property to set the label's text.



Follow the below steps:



Step 1: Add a property in form1 to retrieve value from textbox.

      public string textBox1Text
      {
         get
         {
             return textBox1.Text;
         }
      }

Step 2: Add a property in form2 to set the labels' text


      public string label1Text
      {
          set
          {
              label1.Text = value;
          }
      }

Step 3: In form1's button click event handler add the following code.

    private void button1_Click(object sender, EventArgs e)
    {
       Form2 frm2 = new Form2
       {
           label1Text = textBox1Text
       };

       frm2.Show();
     }        

### The Delegates Approach



Technically, a delegate is a reference type used to encapsulate a method with a specific signature and return type. You can encapsulate any matching method in that delegate. Here we are going to create a delegate with some signature and assign a function to the delegate to assign the text from textbox to label.



Follow the below steps:



Step 1: Add a delegate signature to form1 as below

     public delegate void delPassData(TextBox text);

Step 2: In form1's button click event handler instantiate form2 class and delegate. Assign a function in form2 to the delegate and call the delegate as below

     private void btnSend_Click(object sender, System.EventArgs e)

     {

          Form2 frm= new Form2();

          delPassData del=new delPassData(frm.funData);

          del(this.textBox1);

          frm.Show();

     }

Step 3: In form2, add a function to which the delegate should point to. This function will assign textbox's text to the label.

     public void funData(TextBox txtForm1)

     {

          label1.Text = txtForm1.Text;

     }



### Conclusion



These four approaches are very simple in implementing data passing between forms. There are also other methods available in accomplishing the same. Source code for the methods I stated above is given at the top for download. It is time for you to put your thinking cap and find other ways of doing this. Happy Coding!!!
