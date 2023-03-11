# Delve debugging

## Tip 1 - remember to remove -trimpath flag
When build the program for dlv debugging, besides adding the `-gcflags`, we need to remove the `-trimpath` option , otherwise the dlv cannot find the path...   
Some open source project will include this.

<p align="center">
<img src="../images/delve-2.png" width="80%">
</p>

## Tip 2 - pass parameter to CLI progrm
When you want to debug CLI and pass parameter.   
[Video intro](https://www.youtube.com/watch?v=2kjmLQY8RJk&t=61s&ab_channel=PeterCooper)

<p align="center">
<img src="../images/delve-3.png" width="80%">
</p>

## Tip 3 - debug container running in k8s

<p align="center">
<img src="../images/delve-1.png" width="80%">
</p>


[Notes in PDF](../documents/delve_debugger_v2.pdf)