$(function () {
    var l = abp.localization.getResource('ProjectManagement');

    var dataTable = $('#ProjectsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[0, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(
                myTaskManager.projects.project.getList),
            columnDefs: [
                {
                    title: l('ProjectName'),
                    data: "projectName"
                },
                {
                    title: l('ProjectDescription'),
                    data: "projectDescription",
                },
                {
                    title: l('DeadLine'),
                    data: "deadLine",
                    dataFormat: 'date'
                }
            ]
        })
    );
});