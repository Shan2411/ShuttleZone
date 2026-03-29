INSERT INTO transactions 
(receipt_no, transaction_date, transaction_time, income_type, item_name, quantity, unit_price, payment_method, created_at, court_id, transaction_source)
VALUES
-- Court only transactions
('655473', '2025-03-26', '16:26:22', 'Court', 'Court D', 3, 250.00, 'Cash', '2025-03-26 16:26:22', 1024, 'Frontdesk'),
('462188', '2025-03-26', '16:26:27', 'Court', 'Court C', 2, 250.00, 'Cash', '2025-03-26 16:26:27', 1023, 'Frontdesk'),

-- Membership
('482970', '2025-03-26', '16:26:38', 'Membership', '1 Month Membership', 2, 500.00, 'Cash', '2025-03-26 16:26:38', NULL, 'Frontdesk'),

-- Single court booking
('613539', '2025-03-26', '16:52:06', 'Court', 'Court D', 1, 250.00, 'Cash', '2025-03-26 16:52:06', 1024, 'Frontdesk'),

-- Kiosk grouped receipt (multiple items)
('RCP-20250326-165226', '2025-03-26', '16:52:26', 'Court', 'Badminton Court', 1, 250.00, 'E-Cash', '2025-03-26 16:52:26', NULL, 'Kiosk'),
('972012', '2025-03-26', '16:52:26', 'Court', 'Badminton Court', 1, 250.00, 'E-Cash', '2025-03-26 16:52:26', NULL, 'Frontdesk'),

-- Another grouped transaction (same receipt_no)
('RCP-20250326-172923', '2025-03-26', '17:29:23', 'Court', 'Badminton Court', 1, 250.00, 'E-Cash', '2025-03-26 17:29:23', NULL, 'Kiosk'),
('RCP-20250326-172923', '2025-03-26', '17:29:23', 'Other', 'Grip Tape', 3, 30.00, 'E-Cash', '2025-03-26 17:29:23', NULL, 'Kiosk'),
('RCP-20250326-172923', '2025-03-26', '17:29:23', 'Other', 'Towel', 1, 20.00, 'E-Cash', '2025-03-26 17:29:23', NULL, 'Kiosk');