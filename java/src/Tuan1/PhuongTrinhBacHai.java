package Tuan1;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.text.DecimalFormat;

import javax.swing.*;

public class PhuongTrinhBacHai extends JFrame implements ActionListener {
	JTextField txtA, txtB, txtC, txtKetQua;
	JLabel lblA, lblB, lblC, lblKetQua, lblTitle;
	JButton btnGiai, btnXoaRong,btnThoat;
	
	public PhuongTrinhBacHai() {
		super("Phương Trình Bậc Hai ");
		
		JPanel PNorth = new JPanel();
		lblTitle = new JLabel("GIẢI PHƯƠNG TRÌNH BẬC HAI");
		lblTitle.setFont(new Font("Time New Roman", Font.BOLD, 20));
		PNorth.add(lblTitle);
		PNorth.setBackground(Color.BLUE);
		add(PNorth, BorderLayout.NORTH);
		
		JPanel PCenter = new JPanel();
		PCenter.setLayout(null);
		
		int x = 20, y = 40, width = 100, height = 30;
		
		PCenter.add(lblA = new JLabel("Nhập a:"));
		lblA.setBounds(x, y, width, height); y+=50;
		PCenter.add(lblB = new JLabel("Nhập b:"));
		lblB.setBounds(x, y, width, height); y+=50;
		PCenter.add(lblC = new JLabel("Nhập c:"));
		lblC.setBounds(x, y, width, height); y+=50;
		PCenter.add(lblKetQua = new JLabel("Ket Qua:"));
		lblKetQua.setBounds(x, y, width, height);
		
		x = 80; y = 40; width = 250; height = 30;
		
		PCenter.add(txtA = new JTextField(10));
		txtA.setBounds(x, y, width, height); y+=50;
		PCenter.add(txtB = new JTextField(10));
		txtB.setBounds(x, y, width, height); y+=50;
		PCenter.add(txtC = new JTextField(10));
		txtC.setBounds(x, y, width, height); y+=50;
		PCenter.add(txtKetQua = new JTextField(10));
		txtKetQua.setBounds(x, y, width, height);
		txtKetQua.setEditable(false);
		
		add(PCenter, BorderLayout.CENTER);
		
		JPanel PBottom = new JPanel();
		PBottom.setBorder(BorderFactory.createTitledBorder("Chọn tác vụ"));
		
		PBottom.add(btnGiai = new JButton("Giải"));
		PBottom.add(btnXoaRong = new JButton("Xóa Rỗng"));
		PBottom.add(btnThoat = new JButton("Thoát"));
		add(PBottom, BorderLayout.SOUTH);
		
		btnGiai.addActionListener(this);
		btnXoaRong.addActionListener(this);
		btnThoat.addActionListener(this);
		
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setSize(400, 400);
		setVisible(true);
	}
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		new PhuongTrinhBacHai();
	}
	@Override
	public void actionPerformed(ActionEvent e) {
		int a, b, c;
		double x1, x2;
		DecimalFormat df = new DecimalFormat("0.#");
		a = Integer.parseInt(txtA.getText());
		b = Integer.parseInt(txtB.getText());
		c = Integer.parseInt(txtC.getText());
		
		Object source = e.getSource();
		if(source.equals(btnGiai)) {
			if (a == 0) {
				if (b == 0) {
					if (c == 0) {
						txtKetQua.setText("Phương trình vô số nghiệm");
					}
					else {
						txtKetQua.setText("Phương trình vô nghiệm");
					}
				}
				else {
					x1 = -1.0 * c / b;
					txtKetQua.setText(Double.toString(x1));
				}
			}
			else {
				int delta = b * b - 4 * a * c;
				if (delta < 0) {
					txtKetQua.setText("Phương trình vô nghiệm");
				}
				else if (delta == 0) {
					x1 = -b / (2 * a);
					txtKetQua.setText(Double.toString(x1));
				}
				else {
					x1 = (-b + Math.sqrt(delta)) / (2 * a);
					x2 = (-b - Math.sqrt(delta)) / (2 * a);
					txtKetQua.setText("x1=" + x1 + ", x2=" + x2);
				}
			}
		}
		else if (source.equals(btnXoaRong)) {
			txtA.setText("");
			txtB.setText("");
			txtC.setText("");
			txtKetQua.setText("");
		}
		else if (source.equals(btnThoat)) {
			System.exit(0);
		}
	}

}
