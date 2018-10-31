 google.charts.load("current", {packages:["corechart"]});
      google.charts.setOnLoadCallback(drawChart);
      function drawChart() {
        var data = google.visualization.arrayToDataTable([
          ['', ''],
          ['Usada',     11],
          ['Livre',      2]
        ]);

        var options = {
            pieHole: 0.9,
            backgroundColor: { fill: 'rgb(16,16,16)' },
            colors: ['rgb(226,26,47)', 'rgb(16,16,16)'],
            pieSliceBorderColor: "transparent"


        };
          
        var chart = new google.visualization.PieChart(document.getElementById('donutchart'));
        chart.draw(data, options);
}
