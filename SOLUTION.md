# The Kryon Challenge

## Changed files

- Added Newtonsoft dependency.
- Changed Program.cs
- Added OCRResult class
- Added RecognitionResult class
- Added Word class
- Added Line class

## Broken Code

When I tried to run the code, it didn't let me because it tried to run on .NET 2.1, which is no longer maintained, so I switch it to run on .NET 7.

Afterwards, it didn't run because we were missing Newtonsoft NuGet, so we had to install that.

After that, the code ran well, but printed out the whole result object, which is the OCR result from reading handwritten text.The printed object includes the bounding box and individual words. So as I understood the task, I need to print out only the important information, the text output of the image. So I created classes that follow the JSON Schema that we got and deserialized it using Newtonsoft to the objects. Now I just printed out the text output and saw that we are printing out the names of leaders.

## The Results

The program sends the images to an OCR REST API to recognize handwriting.

All the images are names of leaders in history, specifically The Russian Empire and The United States of America.

Peter The Great was the first Tsar of Russia.

Catherine The Great was the Eigth Tsar of Russia.

George Washington was the first President of the United States.

Thomas Jefferson was the third President of the United States.
