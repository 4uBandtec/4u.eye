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
            backgroundColor: { fill: 'transparent' }
        };

        var chart = new google.visualization.PieChart(document.getElementById('donutchart'));
        chart.draw(data, options);
      }