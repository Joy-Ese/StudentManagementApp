namespace StudentManagementLibrary;

internal class StudentProcess
{
    public string FormatDate(DateTime date){
        var newDate = date.ToString("yyyy MMM dd");
        return newDate;
}
}
