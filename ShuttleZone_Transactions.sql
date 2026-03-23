-- ============================================================
--  ShuttleZone — Transactions Table
--  Run this in MySQL Workbench / phpMyAdmin / MySQL CLI
--  against your existing `shuttlezone` database
-- ============================================================

USE `shuttlezone`;

DROP TABLE IF EXISTS `transactions`;
CREATE TABLE `transactions` (
    `transaction_id`   INT           AUTO_INCREMENT PRIMARY KEY,
    `receipt_no`       VARCHAR(20)   NOT NULL,
    `transaction_date` DATE          NOT NULL,
    `transaction_time` TIME          NOT NULL,
    `income_type`      ENUM('Court','Equipment','Membership','Other') NOT NULL,
    `item_name`        VARCHAR(100)  NOT NULL,
    `quantity`         INT           NOT NULL DEFAULT 1,
    `unit_price`       DECIMAL(10,2) NOT NULL,
    `total_amount`     DECIMAL(10,2) NOT NULL,
    `payment_method`   VARCHAR(50)   NOT NULL,
    `created_at`       DATETIME      NOT NULL DEFAULT CURRENT_TIMESTAMP,

    -- Link to courts table when income_type = 'Court' (optional)
    `court_id`         INT           NULL,
    CONSTRAINT `fk_transactions_court`
        FOREIGN KEY (`court_id`) REFERENCES `courts`(`court_id`)
        ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Fast indexes for Reports date-range queries
CREATE INDEX `idx_transactions_date`
    ON `transactions` (`transaction_date`);

CREATE INDEX `idx_transactions_type_date`
    ON `transactions` (`income_type`, `transaction_date`);

-- ============================================================
--  Sample data so Reports show something right away
--  (Delete this block once real transactions come in)
-- ============================================================
INSERT INTO `transactions`
    (`receipt_no`, `transaction_date`, `transaction_time`,
     `income_type`, `item_name`, `quantity`, `unit_price`, `total_amount`, `payment_method`, `court_id`)
VALUES
    ('100001','2025-02-08','09:00:00','Court',    'Court A Rental',1,13000,13000,'Cash',  123),
    ('100001','2025-02-08','09:00:00','Equipment','Rackets',       2, 1000, 2000,'Cash',  NULL),
    ('100002','2025-02-08','11:00:00','Membership','Monthly Plan', 1, 2500, 2500,'GCash', NULL),
    ('100003','2025-02-09','09:00:00','Court',    'Court B Rental',1,14500,14500,'Cash',  1234),
    ('100003','2025-02-09','09:00:00','Equipment','Shuttlecocks',  3,  500, 1500,'Cash',  NULL),
    ('100004','2025-02-09','10:30:00','Equipment','Court Shoes',   1, 3500, 3500,'GCash', NULL),
    ('100005','2025-02-09','13:00:00','Membership','Monthly Plan', 1, 2000, 2000,'Cash',  NULL),
    ('100006','2025-02-10','09:00:00','Court',    'Court A Rental',1,12000,12000,'Cash',  123),
    ('100006','2025-02-10','09:00:00','Equipment','Rackets',       1, 1500, 1500,'GCash', NULL),
    ('100007','2025-02-10','12:00:00','Equipment','Accessories',   2, 1500, 3000,'Cash',  NULL),
    ('100008','2025-02-10','14:00:00','Membership','Monthly Plan', 1, 2500, 2500,'Cash',  NULL),
    ('100009','2025-02-11','09:00:00','Court',    'Court C Rental',1,15500,15500,'Cash',  12345),
    ('100009','2025-02-11','09:00:00','Equipment','Rackets',       2, 1000, 2000,'GCash', NULL),
    ('100010','2025-02-11','11:30:00','Equipment','Shuttlecocks',  4,  500, 2000,'Cash',  NULL),
    ('100010','2025-02-11','11:30:00','Equipment','Court Shoes',   1, 1800, 1800,'Cash',  NULL),
    ('100011','2025-02-11','14:00:00','Membership','Monthly Plan', 1, 3500, 3500,'GCash', NULL),
    ('100012','2025-02-12','09:00:00','Court',    'Court B Rental',1,14000,14000,'Cash',  1234),
    ('100012','2025-02-12','09:00:00','Equipment','Rackets',       1, 1500, 1500,'Cash',  NULL),
    ('100013','2025-02-12','11:00:00','Equipment','Accessories',   1, 1500, 1500,'GCash', NULL),
    ('100013','2025-02-12','11:00:00','Equipment','Shuttlecocks',  2,  500, 1000,'Cash',  NULL),
    ('100014','2025-02-12','14:00:00','Membership','Monthly Plan', 1, 3000, 3000,'Cash',  NULL),
    ('100015','2025-02-13','09:00:00','Court',    'Court D Rental',1,16000,16000,'Cash',  123456),
    ('100015','2025-02-13','09:00:00','Equipment','Rackets',       2, 1000, 2000,'GCash', NULL),
    ('100016','2025-02-13','11:00:00','Equipment','Court Shoes',   2, 1800, 3600,'Cash',  NULL),
    ('100016','2025-02-13','11:00:00','Equipment','Shuttlecocks',  1,  600,  600,'Cash',  NULL),
    ('100017','2025-02-13','14:30:00','Membership','Monthly Plan', 1, 4500, 4500,'GCash', NULL),
    ('100018','2025-02-14','09:00:00','Court',    'Court A Rental',1,19000,19000,'Cash',  123),
    ('100018','2025-02-14','09:00:00','Equipment','Rackets',       2, 1500, 3000,'Cash',  NULL),
    ('100019','2025-02-14','11:00:00','Equipment','Shuttlecocks',  3,  500, 1500,'GCash', NULL),
    ('100019','2025-02-14','11:00:00','Equipment','Court Shoes',   1, 1800, 1800,'Cash',  NULL),
    ('100020','2025-02-14','14:00:00','Equipment','Accessories',   1,  700,  700,'Cash',  NULL),
    ('100020','2025-02-14','14:00:00','Membership','Monthly Plan', 1, 5000, 5000,'Cash',  NULL);
