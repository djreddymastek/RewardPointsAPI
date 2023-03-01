Overall, this implementation provides a simple and straightforward way to calculate and retrieve reward points earned by each customer per month and total, given a record of every transaction during a three-month period.

We can use swagger UI to test this. Just run this app and it will load https://localhost:7218/swagger/index.html where we can test two methods.

Data used for testing is

Customer ID	Date	    Amount
1	        2023-01-01	60.00
1	        2023-02-01	120.00
1	        2023-03-01	80.00
2	        2023-01-01	90.00
2	        2023-02-01	70.00
2	        2023-03-01	110.00

Total Summary

    curl -X 'GET' \
    'https://localhost:7218/get' \
    -H 'accept: text/plain'

    Request URL - https://localhost:7218/get

    Response

    [
      {
        "customerId": 1,
        "totalPoints": 130
      },
      {
        "customerId": 2,
        "totalPoints": 130
      }
    ]

Monthly Summary


    curl -X 'GET' \
    'https://localhost:7218/getmonthly' \
    -H 'accept: text/plain'

    Request URL - https://localhost:7218/getmonthly

    Response

    [
      {
        "customerId": 1,
        "month": 1,
        "totalPoints": 10
      },
      {
        "customerId": 1,
        "month": 2,
        "totalPoints": 90
      },
      {
        "customerId": 1,
        "month": 3,
        "totalPoints": 30
      },
      {
        "customerId": 2,
        "month": 1,
        "totalPoints": 40
      },
      {
        "customerId": 2,
        "month": 2,
        "totalPoints": 20
      },
      {
        "customerId": 2,
        "month": 3,
        "totalPoints": 70
      }
    ]