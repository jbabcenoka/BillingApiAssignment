**The task:**
"XYZ Inc." is an imaginary company with main business focus on selling a variety of
goods and services online via their E-Shop platform. Currently, there is a need for a
new billing API that could process orders.
Each incoming order should contain:
1. Order number;
2. User id;
3. Payable amount;
4. Payment gateway (identifier to map appropriate payment gateway);
5. Optional description.

When the billing service processes order, it sends the order to an appropriate
payment gateway. If the order is processed successfully by the payment gateway,
the billing service creates a receipt and returns it in response.

**Comments:**
1. The solution contains an example of how Billing Api can be developed and how payment gateways can be handled and processed. The example doesn`t consist of a real payment gateway configuration.
To integrate the specific payment gateway, one must figure out what needs to be requested from the payment gateway and what contains his response.
To test a specific payment gateway, a test account with the provided test credentials by the payment system must be used.
2. The solution contains examples of Billing API unit tests.
